using Core.Utilities.Results;
using eCademiaApp.Business.Abstract;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        // Injectable services
        private readonly IInstructorDal _instructorDal;

        // Injecting our services to establish a loosely coupled connection
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        /// <summary>This method returns a specific instructor by id.</summary>
        /// <param name="id">instructor id</param>
        [SecuredOperation("instructor.view,admin")]
        public IDataResult<Instructor> GetById(int id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(c => c.Id == id));
        }

        /// <summary>This method returns all instructors.</summary>
        [SecuredOperation("instructor.view,admin")]
        public IDataResult<List<Instructor>> GetAll()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll());
        }

        /// <summary>This method saves a instructor to DB.</summary>
        /// <param name="instructor">instructor object</param>
        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);

            return new SuccessResult(Messages.InstructorAdded);
        }

        /// <summary>This method updates a specific instructor from DB.</summary>
        /// <param name="instructor">instructor object</param>
        [SecuredOperation("instructor.update,admin")]
        public IResult Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);

            return new SuccessResult(Messages.InstructorUpdated);
        }

        /// <summary>This method removes a specific instructor from DB.</summary>
        /// <param name="instructor">instructor object</param>
        [SecuredOperation("instructor.delete,admin")]
        public IResult Delete(Instructor instructor)
        {
            _instructorDal.Delete(instructor);

            return new SuccessResult(Messages.InstructorDeleted);
        }
    }
}
