using System.Threading.Tasks;
using Business_Tier_SEP3.Logic.ServiceGroup;
using Business_Tier_SEP3.Logic.ServiceGroupMember;
using Business_Tier_SEP3.Logic.ServiceInvitation;
using Business_Tier_SEP3.Logic.ServiceNote;
using Business_Tier_SEP3.Logic.ServiceUser;
using Grpc.Core;


namespace Business_Tier_SEP3.Services
{
    public class BusinessServerService : BusinessServer.BusinessServerBase
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private IUserService _userService;
        private IGroupService _groupService;
        private IGroupMemberService _groupMemberService;
        private INoteService _noteService;
        private IInvitationService _invitationService;

        /// <summary>
        /// 1-argument constructor
        /// </summary>
        /// <param name="logger"></param>
        public BusinessServerService(IUserService userService, IGroupService groupService,
            IGroupMemberService groupMemberService, INoteService noteService, IInvitationService invitationService)
        {
            _userService = userService;
            _groupService = groupService;
            _invitationService = invitationService;
            _noteService = noteService;
            _groupMemberService = groupMemberService;
        }

        /// <summary>
        /// Method RegisterUser invokes the method with same name
        /// with the retrieved parameters from UserService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<RegisterReply> RegisterUser(RegisterRequest request, ServerCallContext context)
        {
            return await _userService.RegisterUser(request, context);
        }

        /// <summary>
        /// Method ValidateUser invokes the method with same name
        /// with the retrieved parameters from UserService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> ValidateUser(Request request, ServerCallContext context)
        {
            return await _userService.ValidateUser(request, context);
        }

        /// <summary>
        /// Method EditUser invokes the method with same name
        /// with the retrieved parameters from UserService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> EditUser(EditUserRequest request, ServerCallContext context)
        {
            return await _userService.EditUser(request, context);
        }

        /// <summary>
        /// Method DeleteUser invokes the method with same name
        /// with the retrieved parameters from UserService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> DeleteUser(UserRequest request, ServerCallContext context)
        {
            return await _userService.DeleteUser(request, context);
        }

        /// <summary>
        /// Method GetUserList invokes the method with same name
        /// with the retrieved parameters from UserService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> GetUserList(GetUserRequest request, ServerCallContext context)
        {
            return await _userService.GetUserList(request, context);
        }

        /// <summary>
        /// Method PostNote invokes the method with same name
        /// with the retrieved parameters from NoteService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> PostNote(NoteRequest request, ServerCallContext context)
        {
            return await _noteService.PostNote(request, context);
        }

        /// <summary>
        /// Method PutNote invokes the method with same name
        /// with the retrieved parameters from NoteService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> PutNote(NoteRequest request, ServerCallContext context)
        {
            return await _noteService.PutNote(request, context);
        }

        /// <summary>
        /// Method DeleteNote invokes the method with same name
        /// with the retrieved parameters from NoteService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> DeleteNote(Request request, ServerCallContext context)
        {
            return await _noteService.DeleteNote(request, context);
        }

        /// <summary>
        /// Method GetNoteList invokes the method with same name
        /// with the retrieved parameters from NoteService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> GetNoteList(Request request, ServerCallContext context)
        {
            return await _noteService.GetNoteList(request, context);
        }

        /// <summary>
        /// Method PostGroup invokes the method with same name
        /// with the retrieved parameters from GroupService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> PostGroup(PostGroupRequest request, ServerCallContext context)
        {
            return await _groupService.PostGroup(request, context);
        }


        /// <summary>
        /// Method DeleteGroup invokes the method with same name
        /// with the retrieved parameters from GroupService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> DeleteGroup(Request request, ServerCallContext context)
        {
            return await _groupService.DeleteGroup(request, context);
        }


        /// <summary>
        /// Method PostInvitation invokes the method with same name
        /// with the retrieved parameters from InvitationService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> PostInvitation(PostInvitationRequest request, ServerCallContext context)
        {
            return await _invitationService.PostInvitation(request, context);
        }

        /// <summary>
        /// Method GetInvitationList invokes the method with same name
        /// with the retrieved parameters from InvitationService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> GetInvitationList(Request request, ServerCallContext context)
        {
            return await _invitationService.GetInvitationList(request, context);
        }

        /// <summary>
        /// Method DeleteInvitation invokes the method with same name
        /// with the retrieved parameters from InvitationService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> DeleteInvitation(Request request, ServerCallContext context)
        {
            return await _invitationService.DeleteInvitation(request, context);
        }

        /// <summary>
        /// Method GetGroupMemberList invokes the method with same name
        /// with the retrieved parameters from GroupMembersService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> GetGroupMemberList(Request request, ServerCallContext context)
        {
            return await _groupMemberService.GetGroupMemberList(request, context);
        }

        /// <summary>
        /// Method GetGroupList invokes the method with same name
        /// with the retrieved parameters from GroupService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> GetGroupList(Request request, ServerCallContext context)
        {
            return await _groupService.GetGroupList(request, context);
        }

        /// <summary>
        /// Method AddGroupMember invokes the method with same name
        /// with the retrieved parameters from GroupMembersService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> AddGroupMember(AddGroupMemberRequest request, ServerCallContext context)
        {
            return await _groupMemberService.AddGroupMember(request, context);
        }

        /// <summary>
        /// Method DeleteGroupMember invokes the method with same name
        /// with the retrieved parameters from GroupMembersService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> DeleteGroupMember(UserRequest request, ServerCallContext context)
        {
            return await _groupMemberService.DeleteGroupMember(request, context);
        }

        /// <summary>
        /// Method LeaveGroup invokes the method with same name
        /// with the retrieved parameters from GroupMembersService in 1st tier.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        public override async Task<Reply> LeaveGroup(DeleteGroupMemberRequest request, ServerCallContext context)
        {
            return await _groupMemberService.LeaveGroup(request, context);
        }
    }
}