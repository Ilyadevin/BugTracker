using BugTracker.Models;

namespace BugTracker.ViewModels;

public class UserViewModel
{
    public string Id { get; set; }
    public string UserName { get; set; }
    //TODO: Нужна реализация отображения фото
    public string ProfileImageUrl { get; set; }
}