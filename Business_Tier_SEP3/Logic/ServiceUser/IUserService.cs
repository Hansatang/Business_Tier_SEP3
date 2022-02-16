using System.Threading.Tasks;
using Grpc.Core;


namespace Business_Tier_SEP3.Logic.ServiceUser
{
    public interface IUserService
    {
        public Task<RegisterReply> RegisterUser(RegisterRequest request, ServerCallContext context);
        public Task<Reply> ValidateUser(Request request, ServerCallContext context);
        public Task<Reply> EditUser(EditUserRequest request, ServerCallContext context);
        public Task<Reply> DeleteUser(UserRequest request, ServerCallContext context);
        public  Task<Reply> GetUserList(GetUserRequest request, ServerCallContext context);

    }
}