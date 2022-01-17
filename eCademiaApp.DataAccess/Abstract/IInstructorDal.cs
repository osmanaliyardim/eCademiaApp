using Core.DataAccess;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Abstract
{
    // Repository pattern implementation for instructors
    public interface IInstructorDal : IEntityRepository<Instructor>
    {
    }
}
