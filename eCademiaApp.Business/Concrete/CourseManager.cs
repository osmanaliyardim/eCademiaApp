using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.Business.ValidationRules.FluentValidation;
using eCademiaApp.Core.Aspects.Caching;
using eCademiaApp.Core.Aspects.Validation;
using eCademiaApp.Core.Utilities.Pagination;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        // Injectable services
        private readonly ICourseDal _courseDal;

        // Injecting our service to establish a loosely coupled connection
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        /// <summary>This method saves a new course to DB.</summary>
        /// <param name="course">course object</param>
        [SecuredOperation("course.add,moderator,admin")]
        [ValidationAspect(typeof(CourseValidator))]
        //[CacheRemoveAspect("ICourseService.Get")]
        public IResult Add(Course course)
        {
            _courseDal.Add(course);

            return new SuccessResult(Messages.CourseAdded);
        }

        /// <summary>This method deletes a specific course from DB.</summary>
        /// <param name="Course">course object</param>
        [SecuredOperation("course.delete,moderator,admin")]
        //[CacheRemoveAspect("ICourseService.Get")]
        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);

            return new SuccessResult(Messages.CourseDeleted);
        }

        /// <summary>This method returns all courses from DB.</summary>
        //[CacheAspect]
        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll());
        }

        /// <summary>This method returns all courses with pagination from DB.</summary>
        public IDataResult<List<Course>> GetAllWithPagination(PaginationParameters paginationParameters)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll().OrderBy(c => c.Name)
                .Skip((paginationParameters.PageNumber -1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize).ToList());
        }

        /// <summary>This method returns a specific course with id.</summary>
        /// <param name="id">course id</param>
        //[CacheAspect]
        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == id));
        }

        /// <summary>This method returns all course details.</summary>
        //[CacheAspect]
        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetailsById(int id)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails(c => c.Id == id));
        }

        /// <summary>This method returns a specific course with instructor id.</summary>
        /// <param name="instructorId">type id</param>
        //[CacheAspect]
        public IDataResult<List<CourseDetailDto>> GetCoursesByInstructorId(int instructorId)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails(i => i.InstructorId == instructorId));
        }

        /// <summary>This method returns a specific course with type id.</summary>
        /// <param name="typeId">type id</param>
        //[CacheAspect]
        public IDataResult<List<CourseDetailDto>> GetCoursesByTypeId(int typeId, PaginationParameters paginationParameters)
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails(i => i.CourseTypeId == typeId).OrderBy(c => c.Name)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize).ToList());
        }

        /// <summary>This method updates a specific new course from DB.</summary>
        /// <param name="course">course object</param>
        [SecuredOperation("course.update,moderator,admin")]
        [ValidationAspect(typeof(CourseValidator))]
        //[CacheRemoveAspect("ICourseService.Get")]
        public IResult Update(Course course)
        {
            _courseDal.Update(course);

            return new SuccessResult(Messages.CourseUpdated);
        }
    }
}
