using Microsoft.AspNetCore.Components;
using TarefasAppBlazor.UI.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class ContaUsuario
    {
        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        private string nomeUsuario;
        private string emailUsuario;
        private bool isAuthenticated;

        public ContaUsuario()
        {
            nomeUsuario = string.Empty;
            emailUsuario = string.Empty;
            isAuthenticated = false;
        }
        protected override async Task OnInitializedAsync()
        {
            if (await AuthenticationHelper.IsSignIn())
            {
                var usuario = await AuthenticationHelper.GetUser();

                nomeUsuario = usuario.Nome;
                emailUsuario = usuario.Email;
                isAuthenticated = true;
            }
        }
    }
}