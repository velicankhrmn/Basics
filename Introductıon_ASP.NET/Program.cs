var builder = WebApplication.CreateBuilder(args);

//Service (Container)

builder.Services.AddControllers(); // Kontrollerlarý içe aktar.
builder.Services.AddEndpointsApiExplorer(); // Sistemde bulunan kontrollerlarý tara
builder.Services.AddSwaggerGen(); // Swagger arayüzü ve iþlemleri için swagger eklemesi yapýlýyor.

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
