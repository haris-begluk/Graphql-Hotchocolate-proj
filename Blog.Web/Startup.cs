using Blog.Domain.Entities;
using Blog.GraphQL.Queries;
using Blog.GraphQL.Types;
using Blog.Persistance.Repositories;
using Blog.Persistance.Repositories.Interfaces;
using GraphQL.Server.Ui.Playground;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blog.Web
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
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainDatabase"))
            ); ;
            ///GRAPHQL\\\\\\\\\\\\\\\\\\\\\\\
            ///////////////////////////////// 
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<Query>();
            services.AddGraphQL(sp => SchemaBuilder.New()
                      .AddServices(sp)HotChocolate.SchemaException: 'Unable to create instance of type ``.'
                      .AddQueryType<QueryType>()
                      .AddType<CountryType>()
                      .AddType<AddressType>()
                      .AddType<PostRepository>()
                      .AddType<UserRepository>()
                      .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseWebSockets()
                .UseGraphQL("/graphql")
                .UseGraphiQL("/graphql")
                .UsePlayground("/graphql")
                .UseVoyager("/graphql");



        }
    }
}
