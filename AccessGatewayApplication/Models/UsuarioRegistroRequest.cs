using System.ComponentModel.DataAnnotations;

namespace AccessGatewayApplication.Models;

public class UsuarioRegistroRequest
{
    public Guid? IdUsuario { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    public required string Senha { get; set; }

    [Compare("Senha", ErrorMessage = "As senhas não conferem")]
    public required string SenhaConfirmacao { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public required bool CadastroSimples { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public required string PlanoContratado { get; set; }

    public void AdicionaIdUsuario(Guid idUsuario) => IdUsuario = idUsuario;
}
