using System;
using System.Text.Json.Serialization;

namespace MauiApp2.Models
{
    [Serializable]
    public class User
	{
		public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }

    [JsonSerializable(typeof(List<User>))]
    internal sealed partial class UserContext : JsonSerializerContext
    {

    }
}

