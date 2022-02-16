using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Tier_SEP3.Model;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceInvitation
{
    public class InvitationService : IInvitationService
    {
        /// <summary>
        /// Instance variables, uri defines localhost
        /// </summary>
        private string uri = "http://localhost:8080";
        private readonly HttpClient _client;

        /// <summary>
        /// No-argument constructor
        /// </summary>
        public InvitationService()
        {
            _client = new HttpClient();
        }
        
         /// <summary>
       /// GetInvitationList
       /// Method sends GET request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> GetInvitationList(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/invitations/" + request.Name);
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
       /// PostInvitation
       /// Method sends POST request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> PostInvitation(PostInvitationRequest request, ServerCallContext context)
        {
            Invitation invitation = new Invitation(request.Id, request.GroupId, null, request.InviteeId, null,
                request.InvitorId, null);
            string str = JsonSerializer.Serialize(invitation);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/invitation", content);
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
       /// DeleteInvitation
       /// Method sends DELETE request to persistence layer
       /// </summary>
       /// <param name="request"></param>
       /// <param name="context"></param>
       /// <returns>Exception or reply message</returns>
        public async Task<Reply> DeleteInvitation(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(uri + "/invitation/" + request.Name);
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