using Business_Tier_SEP3.Logic.ServiceGroup;
using Business_Tier_SEP3.Logic.ServiceGroupMember;
using Business_Tier_SEP3.Logic.ServiceInvitation;
using Business_Tier_SEP3.Logic.ServiceNote;
using Business_Tier_SEP3.Logic.ServiceUser;
using Business_Tier_SEP3.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Business_Tier_SEP3
{
    public class Startup
    {

        /// <summary>
        /// This method is used to add services to the container, and is called by the runtime
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupMemberService, GroupMemberService>();
            services.AddScoped<IInvitationService, InvitationService>();
        }
        
        /// <summary>
        /// This method configures the HTTP request pipeline, and is called by the runtime
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGrpcService<BusinessServerService>(); });
        }
    }
}