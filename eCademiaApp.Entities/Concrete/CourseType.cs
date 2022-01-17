using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    public class CourseType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
