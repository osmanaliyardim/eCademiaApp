using Core.Entities;

namespace eCademiaApp.Entities.DTOs
{
    // DB View (joined table) for Course Details
    public class CourseDetailDto : IDto
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public double Point { get; set; }
        public DateTime CreationDate { get; set; }
    }
}