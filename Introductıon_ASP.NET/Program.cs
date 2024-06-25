var builder = WebApplication.CreateBuilder(args);

//Service (Container)

builder.Services.AddControllers(); // Kontrollerlar� i�e aktar.
builder.Services.AddEndpointsApiExplorer(); // Sistemde bulunan kontrollerlar� tara
builder.Services.AddSwaggerGen(); // Swagger aray�z� ve i�lemleri i�in swagger eklemesi yap�l�yor.

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
