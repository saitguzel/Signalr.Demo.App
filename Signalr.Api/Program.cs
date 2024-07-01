using Signalr.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    //options.AddPolicy(name: MyAllowSpecificOrigins,
//    //                  policy =>
//    //                  {
//    //                      policy.WithOrigins("https://localhost:44325/",
//    //                                          "https://localhost:44320/")
//    //                      .AllowAnyHeader()
//    //                      .AllowAnyMethod();
//    //                  });
//    options.AddPolicy(MyAllowSpecificOrigins, builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

builder.Services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .SetIsOriginAllowed((host) => true)
                       .AllowCredentials();
            }));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapHub<ChatHub>("chat-hub");


app.MapControllers();

app.Run();