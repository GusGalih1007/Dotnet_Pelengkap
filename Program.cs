using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Pelengkap.DataBase;
using Pelengkap.Interface;
using Pelengkap.Repository;
using Pelengkap.Service;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

    Log.Information("Starting Web API");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog();

    builder.Services.AddDbContext<ApplicationDBContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    });


    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


    builder.Services.AddScoped<IFileService, FIleService>();
    builder.Services.AddScoped<IExcelService, ExcelService>();
    builder.Services.AddScoped<IStudentJoinRepository, StudentRepository>();
    builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
    builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    builder.Services.AddScoped<ILinqservice, LinqService>();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();

    Log.CloseAndFlush();
