using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicalEvents.DataAccess;
using MusicalEvents.Dto.Request;
using MusicalEvents.Dto.Response;
using MusicalEvents.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace MusicalEvents.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly UserManager<MusicalUserIdentity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<MusicalUserIdentity> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<LoginDtoResponse> Login(DtoLogin request)
    {
        var response = new LoginDtoResponse();

        var identity = await _userManager.FindByEmailAsync(request.Username);

        if (identity == null)
        {
            response.Success = false;
            response.ErrorMessage = "El usuario no existe";
            return response;
        }

        if (!await _userManager.CheckPasswordAsync(identity, request.Password))
        {
            response.ErrorMessage = "Clave incorrecta";
            return response;
        }

        var expiredDate = DateTime.Now.AddHours(1);

        response.ExpiredTime = expiredDate;
        response.FullName = $"{identity.FirstName} {identity.LastName}";
        response.UserCode = identity.UserName;
        response.UserId = identity.Id;

        //var sid = string.Empty;
        //var customer = await _customerRepository.GetItemByEmailAsync(identity.Email);
        //if (customer != null)
        //{
        //    response.CustomerId = customer.Id;
        //    sid = customer.Id;
        //}

        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, identity.UserName),
                new Claim(ClaimTypes.Email, identity.Email),
                new Claim(ClaimTypes.GivenName, response.FullName),
            };

        var roles = await _userManager.GetRolesAsync(identity);
        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
            //response.MenuOptions = role == Constants.RoleAdministrator
            //    ? _options.Value.AdminOptions
            //    : _options.Value.CustomerOptions;
        }

        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bWUgZ3VzdGEgZXN0ZSBjdXJzbyBkZSBwdW50byBuZXQ"));

        var credentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var header = new JwtHeader(credentials);

        var payload = new JwtPayload(
            issuer: "MitoCode",
            audience: "localhost",
            claims: authClaims,
            notBefore: DateTime.Now,
            expires: expiredDate);

        var token = new JwtSecurityToken(header, payload);

        response.Token = new JwtSecurityTokenHandler().WriteToken(token);
        response.Success = true;

        return response;
    }

    [HttpPost]
    public async Task<RegisterUserDtoResponse> Register(RegisterUserDtoRequest request)
    {
        var response = new RegisterUserDtoResponse();

        try
        {
            var result = await _userManager.CreateAsync(new MusicalUserIdentity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age,
                TypeDocument = request.TypeDocument,
                DocumentNumber = request.DocumentNumber,
                UserName = request.UserCode
            }, request.Password);

            if (!result.Succeeded)
            {
                response.ValidationErrors = result.Errors
                    .Select(p => p.Description)
                    .ToList();
            }
            else
            {
                var userIdentity = await _userManager.FindByEmailAsync(request.Email);
                if (userIdentity != null)
                {
                    response.UserId = userIdentity.Id;

                    //await _customerRepository.CreateAsync(new Customer
                    //{
                    //    Name = request.FirstName,
                    //    LastName = request.LastName,
                    //    BirthDate = Convert.ToDateTime(request.BirthDate),
                    //    Dni = "99999999",
                    //    Email = userIdentity.Email
                    //});

                    if (!await _roleManager.RoleExistsAsync(Constants.RoleAdministrator))
                        await _roleManager.CreateAsync(new IdentityRole(Constants.RoleAdministrator));

                    if (!await _roleManager.RoleExistsAsync(Constants.RoleCustomer))
                        await _roleManager.CreateAsync(new IdentityRole(Constants.RoleCustomer));

                    if (await _userManager.Users.CountAsync() == 1)
                    {
                        await _userManager.AddToRoleAsync(userIdentity, Constants.RoleAdministrator);
                    }
                    else
                        await _userManager.AddToRoleAsync(userIdentity, Constants.RoleCustomer);

                }
            }
            response.Success = result.Succeeded;
        }
        catch (Exception ex)
        {
            //_logger.LogCritical(ex.Message);
            response.Success = false;
            response.ValidationErrors = new List<string>
                {
                    ex.Message
                };
        }

        return response;
    }

    [HttpPost]
    public async Task<IActionResult> SendTokenToResetPassword(DtoResetPassword request)
    {
        var userIdentity = await _userManager.FindByEmailAsync(request.Email);

        if (userIdentity == null)
            return NotFound(request.Email);

        var token = await _userManager.GeneratePasswordResetTokenAsync(userIdentity);

        // Aqui enviamos el token al correo del usuario.
        //var senderMail = new System.Net.Mail.MailMessage();
        //senderMail.From = new MailAddress("orlando.erick@gmail.com");
        //senderMail.Subject = "Reseteo de password";
        //senderMail.Body = $"Ud. ha solicitado el reseteo de su contraseña, ingrese este token https://localhost/{token}";



        return Ok(token);
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(DtoConfirmReset request)
    {
        var userIdentity = await _userManager.FindByEmailAsync(request.Email);

        if (userIdentity == null)
            return NotFound(request.Email);

        var identity = await _userManager.ResetPasswordAsync(userIdentity, request.Token, request.NewPassword);

        return Ok(identity);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(DtoChangePassword request)
    {
        var userIdentity = await _userManager.FindByEmailAsync(request.Email);

        if (userIdentity == null)
            return NotFound(request.Email);

        var identity = await _userManager.ChangePasswordAsync(userIdentity, request.OldPassword, request.NewPassword);

        return Ok(identity);
    }
}