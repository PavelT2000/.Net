using System.ComponentModel.DataAnnotations;
using TaskManagerV2._0.Models;

public class User
{
    [Key] 
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя пользователя обязательно.")]
    [StringLength(50, ErrorMessage = "Имя пользователя не должно превышать 50 символов.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Электронная почта обязательна.")]
    [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен.")]
    [StringLength(100, ErrorMessage = "Пароль должен быть от 6 до 100 символов.", MinimumLength = 6)]
    public string PasswordHash { get; set; }

    
    public List<MyTask> Tasks { get; set; } = new List<MyTask>();
}