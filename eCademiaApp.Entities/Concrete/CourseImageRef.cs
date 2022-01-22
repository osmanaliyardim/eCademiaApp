using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    public class CourseImageRef : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CourseImageId { get; set; }
    }
}
