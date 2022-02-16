using System.Threading.Tasks;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceGroupMember
{
    public interface IGroupMemberService
    {
        public Task<Reply> GetGroupMemberList(Request request, ServerCallContext context);

        public Task<Reply> AddGroupMember(AddGroupMemberRequest request, ServerCallContext context);
        public Task<Reply> DeleteGroupMember(UserRequest request, ServerCallContext context);
        public Task<Reply> LeaveGroup(DeleteGroupMemberRequest request, ServerCallContext context);
    }
}