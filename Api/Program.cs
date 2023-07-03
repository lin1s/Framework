using Core.Base.DBContext;
using Core.Base.Implementation;
using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("TestDbA"));
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {

                var allTypes = Assembly.Load(assemblyName).GetTypes();
                foreach (var type in allTypes)
                {
                    if (typeof(IScopedInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("IScopedInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddScoped(interfaceType, type);
                        }
                    }
                    else if (typeof(ISingletonInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ISingletonInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddSingleton(interfaceType, type);
                        }
                    }
                    else if (typeof(ITransientInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                    {
                        //  获取当前实现类的接口，但不包含我们的标记类
                        var interfaceTypes = type.GetInterfaces().Where(p => !p.FullName.Contains("ITransientInterface"));
                        foreach (var interfaceType in interfaceTypes)
                        {
                            builder.Services.TryAddTransient(interfaceType, type);
                        }
                    }
                }
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //启动Https路由转换
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}