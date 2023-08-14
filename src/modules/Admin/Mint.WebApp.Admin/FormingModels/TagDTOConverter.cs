using Mint.Domain.Models.Admin;
using Mint.WebApp.Admin.DTO_s;

namespace Mint.WebApp.Admin.FormingModels;

public class TagDTOConverter
{
    public static IEnumerable<TagFullViewModel> FormingMultiViewModels(List<Tag> models)
    {
		try
		{
			var tags = new List<TagFullViewModel>();
			foreach (var model in models)
			{
				tags.Add(new TagFullViewModel()
				{
					Value = model.Id,
					Label = model.Name,
					Translate = model.Translate,
				});
			}
			return tags;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
