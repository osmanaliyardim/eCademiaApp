using Core.Utilities.Results;
using eCademiaApp.Core.Utilities.Pagination;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Abstract
{
    // Course methods as a service to use them from different places with loosely coupling structure
    public interface ICourseService
    {
        IDataResult<Course> GetById(int id);
        IDataResult<List<Course>> GetAll();
        IDataResult<List<Course>> GetAllWithPagination(PaginationParameters paginationParameters);
        IDataResult<List<CourseDetailDto>> GetCoursesByTypeId(int typeId);
        IDataResult<List<CourseDetailDto>> GetCoursesByInstructorId(int instructorId);

        IDataResult<List<CourseDetailDto>> GetCourseDetails();
        IDataResult<List<CourseDetailDto>> GetCourseDetailsById(int id);

        IResult Add(Course course);
        IResult Update(Course course);
        IResult Delete(Course course);
    }
}
