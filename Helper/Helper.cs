using System.Text.Json;
using System.Text;
using Consul;

namespace Helpers
{
    public static class Helper
    {
        public static async Task<T?> GetValueAsync<T>(string key)
        {
            using (var client = new ConsulClient())
            {
                var getPair = await client.KV.Get(key);

                if (getPair?.Response == null)
                {
                    return default(T);
                }

                var value = Encoding.UTF8.GetString(getPair.Response.Value, 0, getPair.Response.Value.Length);

                return JsonSerializer.Deserialize<T>(value);
            }
        }
        public static bool ValidateCustomer(string email)
        {
            //check customer email if not validated
            var allowedEmails = Helper.GetValueAsync<string>(key: "AllowedEmails").Result;
            if (allowedEmails != null && allowedEmails.Contains(email))
            {
                return true;
            }
            return false;
        }
    }
}
