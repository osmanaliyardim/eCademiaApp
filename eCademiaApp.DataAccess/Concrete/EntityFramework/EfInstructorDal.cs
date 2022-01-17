using Core.DataAccess.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    // Repository pattern implementation for Instructors with EntityFramework
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, eCademiaAppContext>, IInstructorDal
    {
    }
}
