namespace Cadastro.Domain.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }


    }
}