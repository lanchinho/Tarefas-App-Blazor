using Microsoft.AspNetCore.Components;
using TarefasAppBlazor.Services.Model.Requests;
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Model.Responses;

namespace TarefasAppBlazor.UI.Pages.App
{
	public partial class CadastrarTarefas
	{
		[Inject]
		private AuthenticationHelper AuthenticationHelper { get; set; }

		private TarefasCadastroRequestModel model = new();
		private List<string> Categorias = new List<string>();
		private string? mensagemProcessamento;
		private string? mensagemSucesso;
		private string? mensagemErro;

		//função para capturar o SUBMIT do formulário
		protected async Task OnSubmit()
		{
			try
			{
				var user = await AuthenticationHelper.GetUser();

				var servicesHelper = new ServicesHelper(user.AccessToken);
				var response = await servicesHelper
					.Post<TarefasCadastroRequestModel,TarefasConsultaResponseModel>("tarefas", model);

				mensagemSucesso = "Tarefa cadastrada com sucesso";
				model = new(); //limpa formulário !
			}
			catch (Exception ex)
			{
				mensagemProcessamento = ex.Message;
			}
			finally
			{
				mensagemProcessamento = string.Empty;
			}
		}


		//função executada ao abrir o componente
		protected override Task OnInitializedAsync()
		{
			Categorias.Add("Trabalho");
			Categorias.Add("Estudo");
			Categorias.Add("Lazer");
			Categorias.Add("Família");
			Categorias.Add("Outros");

			return base.OnInitializedAsync();
		}
	}
}