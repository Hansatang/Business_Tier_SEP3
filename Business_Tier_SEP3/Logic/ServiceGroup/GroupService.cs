using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;



namespace Business_Tier_SEP3.Logic.ServiceGroup
{
    public class GroupService : IGroupService
    {
        /// <summary>
        /// Instance variables, uri defines localhost
        /// </summary>
        private string uri = "http://localhost:8080";
        private readonly HttpClient _client;

        /// <summary>
        /// No-argument constructor
        /// </summary>
        public GroupService()
        {
            _client = new HttpClient();
        }
        
        /// <summary>
        /// GetGroupList
        /// Method sends GET request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> GetGroupList(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/groups/" + request.Name);
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
        /// PostGroup
        /// Method sends POST request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> PostGroup(PostGroupRequest request, ServerCallContext context)
        {
            HttpContent content = new StringContent(request.GroupName, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/group/" + request.MemberId, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.StatusCode + responseMessage.ReasonPhrase);
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply
            {
                Message = message
            });
        }


        /// <summary>
        /// DeleteGroup
        /// Method sends DELETE request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> DeleteGroup(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(uri + "/group/" + request.Name);
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
    }
}