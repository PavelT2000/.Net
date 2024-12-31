using System.ComponentModel.DataAnnotations;

public class MyTask
{
    public int Id { get; set; } // Номер задачи

    [Required]
    public string Name { get; set; } // Название задачи
    public string Description { get; set; }

    public DateTime DateTime { get; set; }


    

    



}
