using System.Diagnostics;
using System.Net.Http.Json;
using MauiApp2.Models;

namespace MauiApp2.Services
{
	public class UserService
	{
        HttpClient httpClient;
        public UserService()
        {
            httpClient = new HttpClient();
        }

        List<User> userList;
        public async Task<List<User>> GetUsers()
        {
            if (userList?.Count > 0)
                return userList;

            // Online
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Good!");
                userList = await response.Content.ReadFromJsonAsync(UserContext.Default.ListUser);
            }

            return userList;
        }
    }
}

