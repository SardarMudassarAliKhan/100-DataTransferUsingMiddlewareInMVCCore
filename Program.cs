using _100_DataTransferUsingMiddlewareInMVCCore.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Add the custom middleware to the pipeline
app.UseMiddleware<CustomMiddleware>();

app.UseEndpoints(configure: endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Middleware",
        pattern: "{controller=Middleware}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
