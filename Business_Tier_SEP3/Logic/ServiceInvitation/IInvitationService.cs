using System.Threading.Tasks;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceInvitation
{
    public interface IInvitationService
    {
        public Task<Reply> GetInvitationList(Request request, ServerCallContext context);
        public Task<Reply> PostInvitation(PostInvitationRequest request, ServerCallContext context);
        public Task<Reply> DeleteInvitation(Request request, ServerCallContext context);
    }
}