using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.BearerToken;

using TaskManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManager.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using TaskManager.Models;
var people = new List<Person>
{
    new Person("bob@gmail.com","12345"),
    new Person("tom@gmail.com","45345")


};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ���������, ����� �� �������������� �������� ��� ��������� ������
            ValidateIssuer = true,
            // ������, �������������� ��������
            ValidIssuer = AuthOptions.ISSUER,
            // ����� �� �������������� ����������� ������
            ValidateAudience = true,
            // ��������� ����������� ������
            ValidAudience = AuthOptions.AUDIENCE,
            // ����� �� �������������� ����� �������������
            ValidateLifetime = true,
            // ��������� ����� ������������
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ��������� ����� ������������
            ValidateIssuerSigningKey = true,
        };
    });






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();


app.Map("/data", [Authorize] () => new { message = "Hello World!" });
app.MapPost("/login", (Person loginData) =>
{
    // ������� ������������ 
    Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
    // ���� ������������ �� ������, ���������� ��������� ��� 401
    if (person is null) return Results.Unauthorized();
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Password) };
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)), // ����� �������� 2 ������
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
    // ��������� �����
    var response = new
    {
        access_token = encodedJwt,
        username = person.Email
    };

    return Results.Json(response);
});


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
