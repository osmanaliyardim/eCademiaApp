namespace eCademiaApp.Entities.Concrete
{
    public class CourseImage
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string ImagePath { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
