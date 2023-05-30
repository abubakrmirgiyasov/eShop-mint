using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class ReviewManager
{
    public async Task<Review> FormingFullBindingModel(ReviewBindingModel model)
    {
        try
        {
            var review = new Review()
            {
                Id = Guid.NewGuid(),
                Minuses = model.Minuses,
                Pluses = model.Pluses,
                CommentType = model.CommentType,
                ProductId = model.ProductId,
                ReviewPhotos = new List<ReviewPhoto>(),
                Text = model.Text,
                UserId = model.UserId,
                DateCreate = DateTime.Now,
                Rating = model.Rating,
            };

            for (int i = 0; i < model.Files?.Count; i++)
            {
                review.ReviewPhotos?.Add(new ReviewPhoto()
                {
                    ReviewId = review.Id,
                    Photo = await PhotoManager.CopyPhotoAsync(model.Files[i], review.Id, model.Type!),
                });
            }

            return review;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public ReviewViewModel FormingSingleViewModels(Review model)
    {
        try
        {
            var review = new ReviewViewModel()
            {
                Id = model.Id,
                Minuses = model.Minuses,
                Pluses = model.Pluses,
                Text = model.Text,
                Photos = new List<string>(),
                ProductId = model.ProductId,
                UserId = model.UserId,
                DateCreate = model.DateCreate,
                Rating = model.Rating,
            };

            for (int j = 0; j < model.ReviewPhotos?.Count; j++)
            {
                review.Photos.Add(model.ReviewPhotos[j].Photo.GetImage64());
            }

            return review;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<ReviewViewModel> FormingMultiViewModels(List<Review> models)
    {
        try
        {
            var reviews = new List<ReviewViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                reviews.Add(new ReviewViewModel()
                {
                    Id = models[i].Id,
                    Minuses = models[i].Minuses,
                    Pluses = models[i].Pluses,
                    Text = models[i].Text,
                    Photos = new List<string>(),
                    ProductId = models[i].ProductId,
                    UserId = models[i].UserId,
                    DateCreate = models[i].DateCreate,
                    Rating = models[i].Rating,
                    FullName = $"{models[i].User?.FirstName} {models[i].User?.SecondName}",
                    RateArr = new List<RateViewModel>(),
                });

                var one = models.Where(x => x.Rating >= 1 && x.Rating < 2).ToList();
                var two = models.Where(x => x.Rating >= 2 && x.Rating < 3).ToList();
                var three = models.Where(x => x.Rating >= 3 && x.Rating < 4).ToList();
                var four = models.Where(x => x.Rating >= 4 && x.Rating < 5).ToList();
                var five = models.Where(x => x.Rating >= 5 && x.Rating <= 5).ToList();

                reviews[i].RateArr?.Add(new RateViewModel()
                {
                    OneStar = new double[3] { one.Count, 1, (one.Count / (double)models.Count) * 100.0 },
                    SecondStar = new double[3] { two.Count, 2, (two.Count / (double)models.Count) * 100 },
                    ThirdStar = new double[3] { three.Count, 3, (three.Count / (double)models.Count) * 100 },
                    FourthStar = new double[3] { four.Count, 4, (four.Count / (double)models.Count) * 100 },
                    FifthStar = new double[3] { five.Count, 5, (five.Count / (double)models.Count) * 100 },
                });

                for (int j = 0; j < models[i].ReviewPhotos?.Count; j++)
                {
                    reviews[i]?.Photos?.Add(models[i].ReviewPhotos![j].Photo.GetImage64());
                }
            }

            return reviews;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
