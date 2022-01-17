using Core.DataAccess;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;
using System.Linq.Expressions;

namespace eCademiaApp.DataAccess.Abstract
{
    // Repository pattern implementation for courses
    public interface ICourseDal : IEntityRepository<Course>
    {
        // Adding extra method to get course details
        List<CourseDetailDto> GetCourseDetails(Expression<Func<CourseDetailDto, bool>> filter = null);
    }
}
