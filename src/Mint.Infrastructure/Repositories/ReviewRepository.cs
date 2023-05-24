using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<ReviewViewModel>> GetReviewsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<ReviewViewModel>> GetProductReviewsByIdAsync(Guid id)
    {
        try
        {
            var reviews = await _context.Reviews
                .Include(x => x.User)
                .Include(x => x.Product)
                .Include(x => x.ReviewPhotos!)
                .ThenInclude(x => x.Photo)
                .Where(x => x.ProductId == id)
                .ToListAsync();
            return new ReviewManager().FormingMultiViewModels(reviews);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<ReviewViewModel> NewReviewAsync(ReviewBindingModel model)
    {
        try
        {            
            var review = await new ReviewManager().FormingFullBindingModel(model);

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            var product = await _context.Products
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id ==  model.ProductId)
                ?? throw new Exception("Товар не найден.");

            double rating = 0.0;

            for (int i = 0; i < product.Reviews?.Count; i++)
            {
                rating += product.Reviews[i].Rating;
            }

            product.Rating = rating / product.Reviews!.Count;

            await _context.SaveChangesAsync();

            return new ReviewManager().FormingSingleViewModels(review);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<ReviewViewModel> UpdateReviewAsync(ReviewBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteReviewAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
