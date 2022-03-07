using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é sugerido")]
        public decimal Value { get; set; }

        [Display(Name = "Ativo")]
        public bool Ative { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O nome de cliente é exigido")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual ClientViewModel Client { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O nome de cliente é exigido")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual CategoryViewModel Category { get; set; }

    }
}
