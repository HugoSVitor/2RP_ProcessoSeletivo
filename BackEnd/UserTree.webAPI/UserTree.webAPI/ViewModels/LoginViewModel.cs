using System.ComponentModel.DataAnnotations;

namespace UserTree.webAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o CPF do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
