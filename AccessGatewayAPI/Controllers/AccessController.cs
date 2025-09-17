using AccessGatewayApplication.Models;
using AccessGatewayApplication.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Controller;

namespace AccessGatewayAPI.Controllers;
[Route("api/controle-acesso")]
public class AccessController(IAuthenticationService AuthService,
                              IUserManagementService UserService) : BaseController
{
    private readonly IAuthenticationService AuthService = AuthService;
    private readonly IUserManagementService UserService = UserService;
    [HttpPost("cadastrar-usuario")]
    public async Task<ActionResult> CadastrarUsuario(UsuarioRegistroRequest usuario)
    {
        var cadastro = await AuthService.NovaContaUsuarioAcesso(usuario);

        if (cadastro is null)
        {
            AdicionarErrosProcessamento("Houve um erro ao tentar cadastrar o usuário.");
            return CustomResponse();
        }

        //usuario.AdicionaIdUsuario(cadastro.Value);

        //if (usuario.CadastroSimples)
        //{
        //    var retorno = await UserService.RegistraUsuarioSimples(usuario);

        //    if (retorno is null) 
        //    {
        //        await AuthService.RemoveNovaContaUsuarioAcesso(cadastro);
        //        AdicionarErrosProcessamento("Sistema indisponível, favor tentar mais tarde.");
        //        return CustomResponse();
        //    }

        //    // Generate Token + return dados.

        //    return CustomResponse(retorno); 
        //}


        return CustomResponse(cadastro);
    }
}
