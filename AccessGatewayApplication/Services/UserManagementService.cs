using AccessGatewayApplication.Models;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using System.Net;
using WebApiCore.Extensions;
using WebApiCore.Services;

namespace AccessGatewayApplication.Services;
public interface IUserManagementService
{
    Task<UsuarioRegistradoResponse?> RegistraUsuarioSimples(UsuarioRegistroRequest registro);
}
public class UserManagementService : BaseClientServices, IUserManagementService
{
    private readonly HttpClient httpClient;

    public UserManagementService(HttpClient client, IOptions<ServicesHostSettingsModel> settings)
    {
        httpClient = client;
        httpClient.BaseAddress = new Uri(settings.Value.UserManagementAPI);
    }

    public async Task<UsuarioRegistradoResponse?> RegistraUsuarioSimples(UsuarioRegistroRequest registro)
    {
        var usuarioContent = ObterConteudo(registro);

        var response = await httpClient.PostAsync("/api/usuario/registro-simples", usuarioContent);

        if (response.StatusCode != HttpStatusCode.OK) return null;

        return await DeserializarObjetoResponse<UsuarioRegistradoResponse>(response);

    }
}
