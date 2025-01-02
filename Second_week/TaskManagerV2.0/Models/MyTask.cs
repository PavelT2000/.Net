using System.ComponentModel.DataAnnotations;

namespace TaskManagerV2._0.Models
{
    public class MyTask
    {
        [Key] // Указывает, что это поле является первичным ключом
        public int Id { get; set; }

        [Required(ErrorMessage = "Название задачи обязательно.")]
        [StringLength(100, ErrorMessage = "Название задачи не должно превышать 100 символов.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Описание задачи не должно превышать 500 символов.")]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false; // По умолчанию задача не выполнена

        // Внешний ключ для связи с пользователем
        public int UserId { get; set; }

        // Навигационное свойство для связи с пользователем
        public User User { get; set; }
    }
}
