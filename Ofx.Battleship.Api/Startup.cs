using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ofx.Battleship.Data;
using MediatR;
using Ofx.Battleship.Cqs;
using Ofx.Battleship.Domain.Repositories;
using Ofx.Battleship.Data.Repositories;

namespace Ofx.Battleship.Api
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
            services.AddDbContext<BattleshipContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BattleshipDatabase")));
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new BattleshipProfile());
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
            var cqsAssembly = AppDomain.CurrentDomain.Load("Ofx.Battleship.Cqs");
            services.AddMediatR(Assembly.GetExecutingAssembly(), cqsAssembly);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            SetupIoc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void SetupIoc(IServiceCollection services)
        {
            services.AddTransient<IReadOnlyRepository, ReadOnlyRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
        }
    }
}
