using System.Threading.Tasks;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceNote
{
    public interface INoteService
    {
        public Task<Reply> PostNote(NoteRequest request, ServerCallContext context);
        public Task<Reply> PutNote(NoteRequest request, ServerCallContext context);
        public Task<Reply> DeleteNote(Request request, ServerCallContext context);
        public Task<Reply> GetNoteList(Request request, ServerCallContext context);
    }
}