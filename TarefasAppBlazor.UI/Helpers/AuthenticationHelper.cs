using Blazored.LocalStorage;
using TarefasAppBlazor.Services.Model.Responses;

namespace TarefasAppBlazor.UI.Helpers
{
    public class AuthenticationHelper
    {
        private readonly ILocalStorageService? _localStorageService;
        private const string _key = "tarefas-app";

        public AuthenticationHelper(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SignIn(AutenticarResponseModel model)
        {
            await _localStorageService.SetItemAsync(_key, model);
        }

        public async Task<bool> IsSignIn()
        {
            var model = await _localStorageService.GetItemAsync<AutenticarResponseModel>(_key);
            return model != null && model.Expiration >= DateTime.Now;
        }

        public async Task<AutenticarResponseModel> GetUser()
        {
            return await _localStorageService.GetItemAsync<AutenticarResponseModel>(_key);
        }

        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }
    }
}
