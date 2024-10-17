using Microsoft.EntityFrameworkCore;

namespace ExamenU1
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //HttContext

            //DbContext

            //Servicios de interfaces que se creen 

            //Identity

            //AutoMapper

            //Cors relacionado al frontend
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();  //useRouting

            //useCors

            //useAuthentication

            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllers();
            });
        }
    }
}
