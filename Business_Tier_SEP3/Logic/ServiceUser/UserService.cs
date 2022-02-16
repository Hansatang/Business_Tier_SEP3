using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Tier_SEP3.Model;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceUser
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Instance variables, uri defines localhost
        /// </summary>
        private string uri = "http://localhost:8080";
        private readonly HttpClient _client;

        /// <summary>
        /// No-argument constructor
        /// </summary>
        public UserService()
        {
            _client = new HttpClient();
        }
        
        /// <summary>
       /// ValidateUser
       /// Method sends POST request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> ValidateUser(Request request, ServerCallContext context)
        {
            User temp = new User(0, "", "", request.Name, request.Type);
            string str = JsonSerializer.Serialize(temp);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/user", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                string message = await responseMessage.Content.ReadAsStringAsync();
                User user = JsonSerializer.Deserialize<User>(message);
                if (request.Type.Equals(user.password))
                {
                    return await Task.FromResult(new Reply
                    {
                        Message = message
                    });
                }
            }
            else
            {
                return null;
            }
            return null;
        }

   
       /// <summary>
       /// RegisterUser
       /// Method sends POST request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<RegisterReply> RegisterUser(RegisterRequest request, ServerCallContext context)
        {
            User temp = new User(0, request.FirstName, request.LastName, request.Username, request.Password);
            string str = JsonSerializer.Serialize(temp);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/unregisteruser", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Error " + responseMessage.StatusCode + " " + responseMessage.ReasonPhrase);
            }
            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new RegisterReply
            {
                Message = message
            });
        }

     
       /// <summary>
       /// GetUserList
       /// Method sends GET request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> GetUserList(GetUserRequest request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/users/" + request.Username);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Error " + responseMessage.StatusCode + " " + " " + responseMessage.ReasonPhrase);
            }
            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply
            {
                Message = message
            });
        }

     
       /// <summary>
       /// EditUser
       /// Method sends POST request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> EditUser(EditUserRequest request, ServerCallContext context)
        {
            User temp = new User(request.Id, "", "", "", request.NewPassword);
            string str = JsonSerializer.Serialize(temp);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + $"/user/{request.Id}", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Error " + responseMessage.StatusCode + " " + responseMessage.ReasonPhrase);
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply
            {
                Message = message
            });
        }

   
       /// <summary>
       /// DeleteUser
       /// Method sends DELETE request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> DeleteUser(UserRequest request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(uri + "/user/" + request.Id);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Error " + responseMessage.StatusCode + " " + " " + responseMessage.ReasonPhrase);
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply
            {
                Message = message
            });
        }
    }
}