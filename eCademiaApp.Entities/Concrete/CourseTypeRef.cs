using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    public class CourseTypeRef : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CourseTypeId { get; set; }
    }
}
