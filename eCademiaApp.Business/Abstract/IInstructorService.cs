using Core.Utilities.Results;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Abstract
{
    // Instructor methods as a service to use them from different places with loosely coupling structure
    public interface IInstructorService
    {
        IDataResult<Instructor> GetById(int id);

        IDataResult<List<Instructor>> GetAll();

        IResult Add(Instructor instructor);

        IResult Update(Instructor instructor);

        IResult Delete(Instructor instructor);
    }
}
