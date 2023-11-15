using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CabinetVeterinar.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cabinets");
    options.Conventions.AllowAnonymousToPage("/Cabinets/Index");
    options.Conventions.AuthorizePage("/Cabinets/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Cabinets/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Cabinets/Delete", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Pets/Details");
    options.Conventions.AuthorizePage("/Pets/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Pets/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Pets/Delete", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Emergency", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Vets/Details");
    options.Conventions.AuthorizePage("/Vets/Edit", "AdminPolicy");
    options.Conventions.AuthorizePage("/Vets/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Vets/Delete", "AdminPolicy");
    options.Conventions.AllowAnonymousToPage("/Cabinets/ShowVetAnimals");
});

builder.Services.AddDbContext<CabinetVeterinarContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("CabinetVeterinarContext") ?? throw new InvalidOperationException("Connectionstring 'CabinetVeterinarContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("CabinetVeterinarContext") ?? throw new InvalidOperationException("Connectionstring 'CabinetVeterinarContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();