using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notely.Application.Notes.Queries;
using Notely.Persistence;
using Notely.Persistence.Identity;
using NotelyCore.Domain;

namespace NotelyCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMediatR(typeof(GetNotesQueryHandler).GetTypeInfo().Assembly);

            //services.AddScoped<IRepository<Note>, NoteRepository>();
            services.AddDbContextPool<NotelyCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:NotelyDb"]);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddIdentity<NotelyUser, UserRole>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUserStore<NotelyUser>, UserStore>();
            services.AddTransient<IRoleStore<UserRole>, NotelyRoleStore>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
            });
            services.AddAntiforgery(options => options.HeaderName = "MY-XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SignInManager<NotelyUser> signInManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                if (signInManager.UserManager.FindByNameAsync("dev").Result == null)
                {
                    var result = signInManager.UserManager.CreateAsync(new NotelyUser
                    {
                        UserName = "dev",
                        Email = "dev@app.com"
                    }, "Gandalf99_").Result;
                }
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
