using Microsoft.EntityFrameworkCore;
using UmbracoFood.Data;
using UmbracoFood.Models;

namespace UmbracoFood
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public IConfiguration Configuration { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="webHostEnvironment">The web hosting environment.</param>
        /// <param name="config">The configuration.</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337.
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config, IConfiguration configuration)
        {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            Configuration = configuration;

        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddUmbraco(_env, _config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                .Build();

            services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("umbracoDbDSN")));
            services.AddTransient<FoodDbContext, FoodDbContext>();
            services.AddTransient<IReservation, ReservationService>();
            services.AddTransient<IContactUs, ContactUsService>();
            services.AddTransient<ICommentStories, CommentStoriesService>();
            services.AddTransient<IStories, StoriesService>();

            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "v1";
                config.Title = "API Documentation";
            });

        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseUmbraco()
                .WithMiddleware(u =>
                {
                    u.UseBackOffice();
                    u.UseWebsite();
                })
                .WithEndpoints(u =>
                {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                    u.UseWebsiteEndpoints();
                });

            //Cấu hình định tuyến cho API ContactController
            //app.UseEndpoints(endpoints =>
            //         {
            //             endpoints.MapControllerRoute(
            //                 name: "ContactApi",
            //                 pattern: "api/contact",
            //                 defaults: new { controller = "ContactUs", action = "SubmitForm" }
            //             );
            //         });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "ReservationApi",
            //        pattern: "api/Reservation",
            //        defaults: new { controller = "ReservationController", action = "SendConfirmationEmail" }
            //    );
            //});


        }
    }
}
