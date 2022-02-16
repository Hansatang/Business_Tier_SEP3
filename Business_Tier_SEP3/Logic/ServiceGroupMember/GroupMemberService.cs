using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Tier_SEP3.Model;
using Grpc.Core;



namespace Business_Tier_SEP3.Logic.ServiceGroupMember
{
    public class GroupMemberService : IGroupMemberService
    {
        /// <summary>
        /// Instance variables, uri defines localhost
        /// </summary>
        private string uri = "http://localhost:8080";
        private readonly HttpClient _client;

        /// <summary>
        /// No-argument constructor
        /// </summary>
        public GroupMemberService()
        {
            _client = new HttpClient();
        }
        
        /// <summary>
        /// GetGroupMemberList
        /// Method sends GET request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> GetGroupMemberList(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/groupmemberslist/" + request.Name);
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

        public Task<Reply> GetGroupList(Request request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// AddGroupMember
        /// Method sends POST request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> AddGroupMember(AddGroupMemberRequest request, ServerCallContext context)
        {
            GroupMembers temp = new GroupMembers(0, request.GroupId, null, request.UserId);
            string str = JsonSerializer.Serialize(temp);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/groupmembers", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Error " + responseMessage.StatusCode + " " + " " + responseMessage.ReasonPhrase);
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply()
            {
                Message = message
            });
        }

       /// <summary>
       /// DeleteGroupMember
       /// Method sends DELETE request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> DeleteGroupMember(UserRequest request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(uri + "/groupmembers/" + request.Id);
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
       /// LeaveGroup
       /// Method sends POST request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
       public async Task<Reply> LeaveGroup(DeleteGroupMemberRequest request, ServerCallContext context)
       {
           HttpContent content = new StringContent(request.UserId.ToString(), Encoding.UTF8, "application/json");
           HttpResponseMessage responseMessage =
               await _client.PostAsync(uri + $"/groupmembers/{request.GroupId}", content);
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