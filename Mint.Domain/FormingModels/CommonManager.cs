using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class MenuManager
{
    public List<MenuParentViewModel> FormingModel(List<SubCategory> models)
    {
        try
        {
            var menus = new List<MenuParentViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                menus.Add(new MenuParentViewModel()
                {
                    Id = models[i].Id,
                    ParentName = models[i].Name,
                    ParentOrder = models[i].DisplayOrder,
                    ParentIco = models[i].Ico,
                    ParentBadgeText = models[i].BadgeText,
                    ParentBadgeStyle = models[i].BadgeStyle,
                    MenuChildViewModels = new List<MenuChildViewModel>(),
                });

                for (int j = 0; j < models[i].Categories?.Count; j++)
                {
                    byte[] childBytes = File.ReadAllBytes(models[i].Categories?[j].Photo != null ? models[i].Categories?[j].Photo?.FilePath! : "default-image.png");

                    menus[i].MenuChildViewModels?.Add(new MenuChildViewModel()
                    {
                        Id =  (Guid)(models[i].Categories?[j].Id)!,
                        ChildName =  models[i].Categories?[j].Name,
                        ChildOrder = (int)(models[i].Categories?[j].DisplayOrder)!,
                        ChildPhoto = "data:image/*;base64," + Convert.ToBase64String(childBytes)
                    });
                }
            }
            return menus;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
