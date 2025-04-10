using WWB.Weixin.SDK;
using WWB.Weixin.SDK.ServerMessages;
using WWB.Weixin.Work;
using WWB.Weixin.Work.ServerMessages;

namespace WWB.Weixin.Samples.Work
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
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddWxWork();
            builder.Services.AddWxSdk(option =>
            {
            });
            builder.Services.AddSingleton<IWxWorkEventHandler, WxWorkEventHandler>();
            builder.Services.AddSingleton<IWxSdkEventsHandler, WxSdkEventHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}