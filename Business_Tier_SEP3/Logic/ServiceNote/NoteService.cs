using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Tier_SEP3.Model;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceNote
{
    public class NoteService : INoteService
    {
        /// <summary>
        /// Instance variables, uri defines localhost
        /// </summary>
        private string uri = "http://localhost:8080";
        private readonly HttpClient _client;

        /// <summary>
        /// No-argument constructor
        /// </summary>
        public NoteService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// GetNoteList
        /// Method sends GET request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> GetNoteList(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/notes/" + request.Name);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.StatusCode + responseMessage.ReasonPhrase);
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            return await Task.FromResult(new Reply {Message = message});
        }

     
        /// <summary>
        /// PostNote
        /// Method sends POST request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> PostNote(NoteRequest request, ServerCallContext context)
        {
            Note note = new Note(request.NoteId, request.GroupId,
                request.Week, request.Year, request.Name, request.Status, request.Text);
            string str = JsonSerializer.Serialize(note);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PostAsync(uri + "/note", content);
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
        /// PutNote
        /// Method sends PUT request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> PutNote(NoteRequest request, ServerCallContext context)
        {
            Note note = new Note(request.NoteId, request.GroupId,
                request.Week, request.Year, request.Name, request.Status, request.Text);
            string str = JsonSerializer.Serialize(note);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _client.PutAsync(uri + "/note", content);
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
        /// DeleteNote
        /// Method sends DELETE request to persistence layer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns>Exception or reply message</returns>
        public async Task<Reply> DeleteNote(Request request, ServerCallContext context)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(uri + "/note/" + request.Name);
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