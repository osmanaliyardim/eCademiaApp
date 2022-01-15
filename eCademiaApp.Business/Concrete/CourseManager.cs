using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.Business.ValidationRules.FluentValidation;
using eCademiaApp.Core.Aspects.Validation;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;
using eCademiaApp.Entities.DTOs;

namespace eCademiaApp.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        [SecuredOperation("course.add,moderator,admin")]
        [ValidationAspect(typeof(CourseValidator))]
        public IResult Add(Course course)
        {
            _courseDal.Add(course);

            return new SuccessResult(Messages.CourseAdded);
        }

        [SecuredOperation("course.delete,moderator,admin")]
        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);

            return new SuccessResult(Messages.CourseDeleted);
        }

        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll());
        }

        public IDataResult<Course> GetById(int id)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }

        public IDataResult<List<Course>> GetCoursesByInstructorId(int instructorId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.InstructorId == instructorId));
        }

        public IDataResult<List<Course>> GetCoursesByTypeId(int typeId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(i => i.TypeId == typeId));
        }

        [SecuredOperation("course.update,moderator,admin")]
        [ValidationAspect(typeof(CourseValidator))]
        public IResult Update(Course course)
        {
            _courseDal.Update(course);

            return new SuccessResult(Messages.CourseUpdated);
        }
    }
}
