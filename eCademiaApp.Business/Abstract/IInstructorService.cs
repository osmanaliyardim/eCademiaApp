using Core.Utilities.Results;
using eCademiaApp.Entities.Concrete;

namespace eCademiaApp.Business.Abstract
{
    public interface IInstructorService
    {
        IDataResult<Instructor> GetById(int id);

        IDataResult<List<Instructor>> GetAll();

        IResult Add(Instructor instructor);

        IResult Update(Instructor instructor);

        IResult Delete(Instructor instructor);
    }
}
