using Core.Utilities.Results;
using eCademiaApp.Business.BusinessAspects.Autofac;
using eCademiaApp.Business.Constants;
using eCademiaApp.DataAccess.Abstract;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Concrete
{
    public class InstructorManager
    {
        private readonly IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        [SecuredOperation("customer.view,admin")]
        public IDataResult<Instructor> GetById(int id)
        {
            return new SuccessDataResult<Instructor>(_instructorDal.Get(c => c.Id == id));
        }

        [SecuredOperation("customer.view,admin")]
        public IDataResult<List<Instructor>> GetAll()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll());
        }

        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);

            return new SuccessResult(Messages.InstructorAdded);
        }

        [SecuredOperation("customer.update,admin")]
        public IResult Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);

            return new SuccessResult(Messages.InstructorUpdated);
        }

        [SecuredOperation("customer.delete,admin")]
        public IResult Delete(Instructor instructor)
        {
            _instructorDal.Delete(instructor);

            return new SuccessResult(Messages.InstructorDeleted);
        }
    }
}
