using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
      
    }
}
