using Core.DataAccess.EntityFramework;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;
using System.Linq.Expressions;

namespace eCademiaApp.DataAccess.Concrete.EntityFramework
{
    // Repository pattern implementation for Courses with EntityFramework
    public class EfCourseDal : EfEntityRepositoryBase<Course, eCademiaAppContext>, ICourseDal
    {
        // Adding extra method to return course details (joining tables)
        public List<CourseDetailDto> GetCourseDetails(Expression<Func<CourseDetailDto, bool>> filter = null) //TODO: Can be upgraded with Automapper
        {
            using (var context = new eCademiaAppContext())
            {
                var result = from c in context.Courses
                             join t in context.CourseTypes
                                 on c.Id equals t.CourseId
                             join m in context.CourseImages
                                 on c.Id equals m.CourseId
                             join i in context.Instructors
                                on c.Id equals i.CourseId
                             select new CourseDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Instructor = i.CompanyName,
                                 InstructorId = i.Id,
                                 Type = t.Name,
                                 CourseTypeId = t.Id,
                                 ImagePath = m.ImagePath,
                                 Price = c.Price,
                                 SalePrice = c.SalePrice,
                                 Point = c.Point
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
