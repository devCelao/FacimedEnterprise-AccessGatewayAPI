using AccessGatewayApplication.Models;
using Microsoft.Extensions.Options;
using System.Net;
using WebApiCore.Extensions;
using WebApiCore.Services;

namespace AccessGatewayApplication.Services;
public interface IAuthenticationService
{
    Task<Guid?> NovaContaUsuarioAcesso(UsuarioRegistroRequest registro);
    Task<bool> RemoveNovaContaUsuarioAcesso(Guid? idUsuario);
}
public class AuthenticationService : BaseClientServices, IAuthenticationService
{
    private readonly HttpClient httpClient;

    public AuthenticationService(HttpClient client, IOptions<ServicesHostSettingsModel> settings)
    {
        httpClient = client;
        httpClient.BaseAddress = new Uri(settings.Value.AuthenticationAPI);
    }

    public async Task<Guid?> NovaContaUsuarioAcesso(UsuarioRegistroRequest registro)
    {
        var usuarioContent = ObterConteudo(registro);

        var response = await httpClient.PostAsync("/api/authenticacao/nova-conta", usuarioContent);

        if(response.StatusCode != HttpStatusCode.OK) return null;

        return await DeserializarObjetoResponse<Guid>(response);
    }

    public async Task<bool> RemoveNovaContaUsuarioAcesso(Guid? idUsuario)
    {
        var response = await httpClient.DeleteAsync($"/api/authenticacao/remover/{idUsuario}");

        if (response.StatusCode != HttpStatusCode.OK) return false;

        return true;
    }

    public async Task<string?> GenerateTokenAcesso(UsuarioRegistradoResponse usuario)
    {
        var usuarioContent = ObterConteudo(usuario);

        var response = await httpClient.PostAsync("", usuarioContent);

        if (response.StatusCode != HttpStatusCode.OK) return null;

        return await DeserializarObjetoResponse<string>(response);
    }
}
