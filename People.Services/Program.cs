using People.Services.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(9874));

        // Add services to the container.
        builder.Services.AddSingleton<IPeopleProvider, HardCodePeopleProvider>();

        //builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/people", (IPeopleProvider provider) => provider.GetPeople()).WithName("GetPeople");

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        //app.MapControllers();

        app.Run();
    }
}