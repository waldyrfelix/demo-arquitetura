using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.UI.Mvc.ViewModels
{
    public class ProdutoViewModel
    {
        [DisplayName("Nome do produto:")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(10, ErrorMessage = "Nome muito grande")]
        [UIHint("DestaqueTitulo")]
        public string Nome { get; set; }

        [DisplayName("Preço do produto:")]
        [Required(ErrorMessage = "Campo preço é obrigatório")]
        public decimal Preco { get; set; }
    }
}