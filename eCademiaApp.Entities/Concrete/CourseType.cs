using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for CourseType
    public class CourseType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int ParentId { get; set; }
    }
}
