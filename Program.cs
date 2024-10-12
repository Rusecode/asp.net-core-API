using BlogUser.Data;
using Microsoft.EntityFrameworkCore;
using BlogUser.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o DbContext com o PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Adiciona o serviço de usuário
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Adiciona o suporte a controllers e views
builder.Services.AddControllersWithViews();

// Adiciona a configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Habilita o CORS
app.UseCors("AllowAll");

app.UseStaticFiles();      // Permite servir arquivos estáticos

app.UseRouting();          // Habilita o roteamento

app.UseAuthorization();    // Habilita a autorização

// Mapeia a rota padrão para o controlador
app.MapControllerRoute(
    name: "usuario",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run(); // Inicia a aplicação









