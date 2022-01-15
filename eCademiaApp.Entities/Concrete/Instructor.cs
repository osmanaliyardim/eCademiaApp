namespace eCademiaApp.Entities.Concrete
{
    public class Instructor
    {
        public int Id { get; set; }        
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
