using University.BLL.Services.Contracts;
using University.DAL.DataContext;
using University.DAL.Entities;
using University.DAL.Repositories;

namespace University.BLL.Services
{
    public class StudentManager : EfCoreRepository<Student>, IStudentService
    {
        public StudentManager(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<string> Test()
        { 
            return "test";
        }

        public override Task AddAsync(Student entity)
        {
            entity.CreatedAt = DateTime.Now;
            return base.AddAsync(entity);
        }
    }
}
