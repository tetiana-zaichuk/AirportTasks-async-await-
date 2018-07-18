using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer
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
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AirportContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Airportdb;Trusted_Connection=True;"));

            services.AddMvc();
            //services.AddScoped<DataSeends>();
            //services.AddScoped<AirportContext>();

            //services.AddScoped<IRepository<Aircraft>, Repository<Aircraft>>();
            services.AddScoped<IRepository<AircraftType>, Repository<AircraftType>>();
            services.AddScoped<IRepository<Crew>, Repository<Crew>>();
            services.AddScoped<IRepository<Departure>, Repository<Departure>>();
            services.AddScoped<IRepository<Flight>, Repository<Flight>>();
            services.AddScoped<IRepository<Pilot>, Repository<Pilot>>();
            services.AddScoped<IRepository<Stewardess>, Repository<Stewardess>>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IService<Shared.DTO.Aircraft>, AircraftService>();
            services.AddScoped<IService<Shared.DTO.AircraftType>, AircraftTypeService>();
            services.AddScoped<IServiceCrew, CrewService>();
            services.AddScoped<IService<Shared.DTO.Departure>, DepartureService>();
            services.AddScoped<IService<Shared.DTO.Flight>, FlightService>();
            services.AddScoped<IService<Shared.DTO.Pilot>, PilotService>();
            services.AddScoped<IService<Shared.DTO.Stewardess>, StewardessService>();
            services.AddScoped<IService<Shared.DTO.Ticket>, TicketService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper>(m => GetAutoMapperConfig().CreateMapper());
        }

        private MapperConfiguration GetAutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aircraft, Shared.DTO.Aircraft>();
                cfg.CreateMap<Shared.DTO.Aircraft, Aircraft>();
                cfg.CreateMap<AircraftType, Shared.DTO.AircraftType>();
                cfg.CreateMap<Shared.DTO.AircraftType, AircraftType>();
                cfg.CreateMap<Flight, Shared.DTO.Flight>();
                cfg.CreateMap<Shared.DTO.Flight, Flight>();
                cfg.CreateMap<Pilot, Shared.DTO.Pilot>();
                cfg.CreateMap<Shared.DTO.Pilot, Pilot>().ForMember(p => p.Crew, opt => opt.Ignore());
                cfg.CreateMap<Shared.DTO.Crew, Crew>();
                cfg.CreateMap<Shared.DTO.Pilot10, Shared.DTO.Pilot>()
                    .ForMember("Dob", s => s.MapFrom(m => m.birthDate))
                    .ForMember("Experience", s => s.MapFrom(m => m.exp));
                cfg.CreateMap<Shared.DTO.Stewardess10, Shared.DTO.Stewardess>()
                    .ForMember("Dob", s => s.MapFrom(m => m.birthDate));
            });

            return config;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AirportContext airportContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            DbInitializer.Initialize(airportContext);
        }
    }
}
