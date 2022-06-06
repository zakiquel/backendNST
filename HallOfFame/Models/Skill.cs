using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HallOfFame.Models;

public class Skill
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите название навыка")]
    [MaxLength(50,ErrorMessage ="Название навыка не должно превышать 50 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Укажите уровень навыка")]
    [Range(1, 10, ErrorMessage = "Уровень навыка может быть в диапазоне от 1 до 10")]
    public byte Level { get; set; }// 1-10

    [JsonIgnore]
    public ICollection<Person>? Persons { get; set; }
}