using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    public class CourseImage : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
    }
}
