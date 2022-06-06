using Microsoft.EntityFrameworkCore;
using HallOfFame.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace HallOfFame.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Skill> Skills => Set<Skill>();
}