using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HallOfFame.Models;

public class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите ФИО")]
    [MaxLength(100,ErrorMessage ="ФИО не должно превышать 100 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Введите отображаемое имя")]
    [MaxLength(40,ErrorMessage = "Отображаемое имя не должно превышать 40 символов")]
    public string? DisplayName { get; set; }
    
    public virtual ICollection<Skill>? Skills { get; set; }
}