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
                             join ctr in context.CourseTypeRefs
                                on c.Id equals ctr.CourseId
                             join t in context.CourseTypes
                                 on ctr.CourseTypeId equals t.Id
                             join cir in context.CourseImageRefs
                                 on c.Id equals cir.CourseId
                             join m in context.CourseImages
                                 on cir.CourseImageId equals m.Id
                             join e in context.Enrollments
                                on c.Id equals e.CourseId
                             join i in context.Instructors
                                on e.InstructorId equals i.Id
                             select new CourseDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Description = c.Description,
                                 Instructor = i.CompanyName,
                                 InstructorId = i.Id,
                                 Type = t.Name,
                                 CourseTypeId = t.Id,
                                 ImagePath = m.ImagePath,
                                 Price = c.Price,
                                 SalePrice = c.SalePrice,
                                 Point = c.Point,
                                 CreationDate = c.CreationDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
