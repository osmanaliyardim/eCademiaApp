using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.Business.ValidationRules.FluentValidation;
using eCademiaApp.Core.Aspects.Caching;
using eCademiaApp.Core.Aspects.Validation;
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
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Course course)
        {
            _courseDal.Add(course);

            return new SuccessResult(Messages.CourseAdded);
        }

        /// <summary>This method deletes a specific course from DB.</summary>
        /// <param name="Course">course object</param>
        [SecuredOperation("course.delete,moderator,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);

            return new SuccessResult(Messages.CourseDeleted);
        }

        /// <summary>This method returns all courses from DB.</summary>
        [CacheAspect]
        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll());
        }

        /// <summary>This method returns a specific course with id.</summary>
        /// <param name="id">course id</param>
        [CacheAspect]
        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == id));
        }

        /// <summary>This method returns all course details.</summary>
        [CacheAspect]
        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }

        /// <summary>This method returns a specific course with instructor id.</summary>
        /// <param name="instructorId">instructor id</param>
        [CacheAspect]
        public IDataResult<List<Course>> GetCoursesByInstructorId(int instructorId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.InstructorId == instructorId));
        }

        /// <summary>This method returns a specific course with type id.</summary>
        /// <param name="typeId">type id</param>
        [CacheAspect]
        public IDataResult<List<Course>> GetCoursesByTypeId(int typeId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.TypeId == typeId));
        }

        /// <summary>This method updates a specific new course from DB.</summary>
        /// <param name="course">course object</param>
        [SecuredOperation("course.update,moderator,admin")]
        [ValidationAspect(typeof(CourseValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Course course)
        {
            _courseDal.Update(course);

            return new SuccessResult(Messages.CourseUpdated);
        }
    }
}
