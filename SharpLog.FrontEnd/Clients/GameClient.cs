using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace SharpLog.FrontEnd.Clients
{
    public class GameClient : BaseClient
    {
        public GameClient(
                    HttpClient client,
                    ILocalStorageService localStorageService,
                    NavigationManager navigationManager
                ) : base(client, localStorageService, navigationManager)
        {
        }
    }
}