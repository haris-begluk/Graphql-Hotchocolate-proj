using Blog.Domain;
using Blog.Domain.Entities;
using Blog.GraphQL.EF.Queries;
using Blog.GraphQL.EF.Schemas;
using Blog.GraphQL.EF.Types;
using GraphQL;
using GraphQL.EntityFramework;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.Web.EF
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
            services.AddControllers();
            //services.AddDbContext<BlogDbContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("MainDatabase")));
            services.AddSingleton(_ => { return BlogDbContextEfFactory.CreateDbContext(Configuration); });
            EfGraphQLConventions.RegisterInContainer(
                services,
                userContext => { return BlogDbContextEfFactory.CreateDbContext(Configuration); });
            services.AddGraphQL(options => options.ExposeExceptions = true);
            services.AddSingleton<MainSchema>();
            services.AddSingleton<MainQuery>();
            services.AddSingleton<CountryGraph>();
            services.AddSingleton<AddressGraph>();
            services.AddSingleton<UserGraph>();
            services.AddSingleton<PostGraph>();

            GraphTypeTypeRegistry.Register<Country, CountryGraph>();
            GraphTypeTypeRegistry.Register<Address, AddressGraph>();
            GraphTypeTypeRegistry.Register<User, UserGraph>();
            GraphTypeTypeRegistry.Register<Post, PostGraph>();


            services.AddSingleton<IDocumentExecuter, EfDocumentExecuter>();
            services.AddSingleton<IDependencyResolver>(
                 provider => new FuncDependencyResolver(provider.GetRequiredService));
            services.Configure<KestrelServerOptions>(o => { o.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(o => { o.AllowSynchronousIO = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphQL<MainSchema>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
