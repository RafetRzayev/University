using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.DataContext;
using University.DAL.Entities;
using University.DAL.Repository;
using Unversity.BLL.Services.Contracts;

namespace Unversity.BLL.Services
{
    public class StudentService : EfCoreRepository<Student>, IStudentService
    {
        public StudentService(AppDbContext dbContext) : base(dbContext)
        {
        }

        public object Test()
        {
            return "test";
        }

        public override Task<Student> GetAsync(int? id)
        {
            return base.GetAsync(id);
        }
    }
}
