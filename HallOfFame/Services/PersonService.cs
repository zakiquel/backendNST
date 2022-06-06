using HallOfFame.Models;
using HallOfFame.Data;
using Microsoft.EntityFrameworkCore;


namespace HallOfFame.Services;

public class PersonService
{
    private readonly PersonContext _context;

    
   public PersonService(PersonContext context)
    {
        _context = context;
    }
    // Получение списка всех сотрудников
    public IEnumerable<Person> GetAll()
    {
        return _context.Persons
            .Include(p => p.Skills)
            .AsNoTracking()
            .ToList();
    }
    // Получение сотрудника по идентификатору
    public Person? GetById(int id)
    {
        return _context.Persons
            .Include(p => p.Skills)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Person Create(Person newPerson)
    {
        _context.Persons.Add(newPerson);
        _context.SaveChanges();

        return newPerson;
    }
    // Редактирование сотрудника
    public void PutPerson(int id, Person updatedPerson) 
    {
        var person = _context.Persons.Find(id);

        if(person is null)
            return;

        if(person.Skills is null)
            return;

        _context.Entry(person).CurrentValues.SetValues(updatedPerson);

        var personSkills = person.Skills.ToList();

        foreach (var personSkill in personSkills)
            {
                var skill = updatedPerson.Skills.SingleOrDefault(s => s.Name == personSkill.Name);
                if (skill != null)
                {
                    //обновляем поле у навыка сотрудника
                    _context.Entry(personSkill).CurrentValues.SetValues(skill);
                }
                else
                {
                    //удаляем, если навыка нет
                    _context.Remove(personSkill);
                }
            }

            //добавляем новые навыки
            foreach (var skill in updatedPerson.Skills)
            {
                if (personSkills.All(s => s.Name != skill.Name))
                {
                    person.Skills.Add(skill);
                }
            }

            _context.SaveChanges();   
    }
    //Удаление сотрудника
   public void DeleteById(int id)
    {
        var personToDelete = _context.Persons.Find(id);
        if (personToDelete is not null)
        {
            _context.Persons.Remove(personToDelete);
            _context.SaveChanges();
        }        
    }
}