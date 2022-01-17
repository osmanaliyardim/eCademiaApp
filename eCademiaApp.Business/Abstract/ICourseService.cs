using Core.Utilities.Results;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Abstract
{
    // Course methods as a service to use them from different places with loosely coupling structure
    public interface ICourseService
    {
        IDataResult<Course> GetById(int id);
        IDataResult<List<Course>> GetAll();
        IDataResult<List<Course>> GetCoursesByTypeId(int typeId);
        IDataResult<List<Course>> GetCoursesByInstructorId(int instructorId);

        IDataResult<List<CourseDetailDto>> GetCourseDetails();

        IResult Add(Course course);
        IResult Update(Course course);
        IResult Delete(Course course);
    }
}
