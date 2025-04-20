using Exam.MVC.Extensions;
using Exam.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationServices()
    .AddPersistenceLayer(builder.Configuration);

builder.ConfigureSerilogLogging();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseExceptionHandler("/Home/Error");


app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
