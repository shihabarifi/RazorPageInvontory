using RazorPageInvontory.Modules.UsersSys.ADL;
using RazorPageInvontory.Modules.UsersSys.BLL;
using RazorPageInvontory.ServicesLayer;

var builder = WebApplication.CreateBuilder(args);
// إضافة خدمات Razor Pages
builder.Services.AddRazorPages();

// تسجيل الخدمات في نظام حقن التبعية
builder.Services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
//builder.Services.AddScoped<ISalesInvoiceRepository, SalesInvoiceRepository>();

// إعداد HttpClient للتعامل مع API
builder.Services.AddTransient<AuthenticateUser>();
builder.Services.AddTransient<UserService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5229/") });

builder.Services.AddHttpClient("SalesAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["APISettings:BaseUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
// إضافة إعادة التوجيه للصفحة الافتراضية
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/Login", permanent: false);
        return;
    }
    await next();
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
