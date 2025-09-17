namespace AccessGatewayApplication.Models;

public class UsuarioRegistradoResponse
{
    public Guid IdUsuario { get; set; }
    public string? Email { get; set; }
    public string? Nome { get; set; }
    public ICollection<UsuarioRegistradoFuncaoResponse>? Funcoes { get; set; }
}

public class UsuarioRegistradoFuncaoResponse
{
    public string? CodFuncao { get; set; }
}
