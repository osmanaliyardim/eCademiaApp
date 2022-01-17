using Core.DataAccess.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, eCademiaAppContext>, IInstructorDal
    {
    }
}
