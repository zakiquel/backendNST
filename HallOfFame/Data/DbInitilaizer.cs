using HallOfFame.Models;

namespace HallOfFame.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PersonContext context)
        {

            if (context.Persons.Any()
                && context.Skills.Any())
            {
                return;   
            }

            var CodingSkill = new Skill { Name = "Coding", Level = 1 };
            var MathSkill = new Skill { Name = "Math", Level = 3 };
            var EnglishSkill = new Skill { Name = "English", Level = 7 };
            var CommunicationSkill = new Skill { Name = "Communication", Level = 5 };
            var AdaptabilitySkill = new Skill { Name = "Adaptability", Level = 5 };

            var persons = new Person[]
            {
                new Person
                    {
                        Name = "Stas",
                        DisplayName = "Stanislav",
                        Skills = new List<Skill>
                            {
                                CodingSkill,
                                MathSkill,
                                CommunicationSkill,
                                AdaptabilitySkill
                            }
                    },
                new Person
                    {
                        Name = "Vika",
                        DisplayName = "Viktoria",
                        Skills = new List<Skill>
                            {
                                CommunicationSkill,
                                EnglishSkill,
                                CodingSkill
                            }
                    },
                new Person
                    {
                        Name="Misha",
                        DisplayName = "Mikhail",
                        Skills = new List<Skill>
                            {
                                CodingSkill,
                                MathSkill
                            }
                        }
            };

            context.Persons.AddRange(persons);
            context.SaveChanges();
        }
    }
}