using Microsoft.EntityFrameworkCore;
using Hospital.DAL;
using Hospital.BL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HospitalContext>(options
=> options.UseSqlServer("Server=.; Database=HospitalDb;Trusted_Connection=True ;Encrypt=false"));    //configure context  
//if aske in ctor HospitalContext , use obj of HospitalContext carry options

builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();    //if aske in ctor idocrepo , use obj of doctorrepo
builder.Services.AddScoped<IDoctorsManager, DoctorsManager>();    

////environment
//if (builder.Environment.IsDevelopment()) 
//{
//    //connection string =>
//    builder.Services.AddDbContext<HospitalContext>(options
//    => options.UseSqlServer("Server=YOUR-PRODUCTIONN-SERVER; Database=HospitalDb; Trusted-Connection=true"));        //object of context
//}
//else
//{
//    //connection string =>
//    builder.Services.AddDbContext<HospitalContext>(options
//    => options.UseSqlServer("Server=.; Database=HospitalDb; Trusted-Connection=true"));        //object of context
//}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
