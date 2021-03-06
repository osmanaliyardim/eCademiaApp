using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for CreditCard
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public byte ExpYear { get; set; }
        public string Cvc { get; set; }
        public string CardType { get; set; }
    }
}
