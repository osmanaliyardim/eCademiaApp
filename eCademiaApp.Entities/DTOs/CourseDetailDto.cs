namespace eCademiaApp.Entities.DTOs
{
    public class CourseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public double Point { get; set; }
    }
}