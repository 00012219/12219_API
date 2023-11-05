using DSCC.CW1._12219.API.Db;
using DSCC.CW1._12219.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._12219.API.Services
{
    public class PersonService : IService<Person>
    {
        private readonly AppDbContext dbContext;
        public PersonService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Person item)
        {
            dbContext.Add(item);
            Save();
        }

        public void Delete(int Id)
        {
            var Person = dbContext.Persons.Find(Id);
            dbContext.Persons.Remove(Person);
            Save();
        }

        public IEnumerable<Person> GetAll()
        {
            return dbContext.Persons.ToList();
        }

        public Person GetById(int Id)
        {
            var Person = dbContext.Persons.Find(Id);
            return Person;
        }

        public void Update(Person item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            Save();
        }

        // Method for saving the changes
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
