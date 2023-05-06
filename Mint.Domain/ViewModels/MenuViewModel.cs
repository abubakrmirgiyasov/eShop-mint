namespace Mint.Domain.ViewModels;

public class MenuChildViewModel
{
    public Guid Id { get; set; }

    public string? ChildName { get; set; }

    public string? ChildPhoto { get; set; }
    
    public int ChildOrder { get; set; }

    public string? Link { get; set; }
}

public class MenuParentViewModel
{
    public Guid Id { get; set; }

    public string? ParentName{ get; set; }

    public string? ParentIco{ get; set; }

    public int ParentOrder { get; set; }

    public string? ParentBadgeText { get; set; }

    public string? ParentBadgeStyle { get; set; }

    public List<MenuChildViewModel>? MenuChildViewModels { get; set; }
}