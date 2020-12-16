
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Produto
    {
        #region Properties
            [Required(ErrorMessage = "Id é obrigatório")]
            [StringLength(36)]
            public string Id { get; set; }

            [Required(ErrorMessage = "Codigo é obrigatório")]
            [StringLength(30)]
            public string Codigo { get; set; }

            [Required(ErrorMessage = "Descrição é obrigatório")]
            [StringLength(200)]
            public string Descricao { get; set; }

            [Required(ErrorMessage = "Preço é obrigatório")]            
            public decimal Preco { get; set; }

            public bool Status { get; set; }

            [Required(ErrorMessage = "Departamento é obrigatório")]
            [StringLength(36)]
            public string IdDepartamento { get; set; }
        #endregion
       
    }
}
