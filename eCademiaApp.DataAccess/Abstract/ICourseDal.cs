using Core.DataAccess;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;
using System.Linq.Expressions;

namespace eCademiaApp.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
        List<CourseDetailDto> GetCourseDetails(Expression<Func<CourseDetailDto, bool>> filter = null);
    }
}
