using System.Threading.Tasks;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceGroup
{
    public interface IGroupService
    {
        public Task<Reply> PostGroup(PostGroupRequest request, ServerCallContext context);
    
        public Task<Reply> DeleteGroup(Request request, ServerCallContext context);
        
        public Task<Reply> GetGroupList(Request request, ServerCallContext context);
    }
}