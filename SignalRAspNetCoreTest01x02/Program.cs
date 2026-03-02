using SignalRAspNetCoreTest01x02.Extensions;
using SignalRAspNetCoreTest01x02.Hubs;
using SignalRAspNetCoreTest01x02.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
//添加Swagger并配置JWT（拓展）
builder.Services.AddSwaggerWithJwt();

//允许跨域（拓展）
builder.Services.AddAllowAllCors();

//添加SignalR
builder.Services.AddSignalR();

// 连接管理单例
builder.Services.AddSingleton<ConnectionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.MapHub<ChatHub>("/chatHub");

app.Run();
