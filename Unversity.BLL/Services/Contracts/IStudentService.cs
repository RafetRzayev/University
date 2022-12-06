using University.DAL.Entities;
using University.DAL.Repository.Contracts;

namespace Unversity.BLL.Services.Contracts
{
    public interface IStudentService : IRepository<Student>
    {
        object Test();
    }
}
