using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Exceptions;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DaraTransferObject.IdentityDtos;
using Shared.DaraTransferObject.IdentiyDto;

namespace Service
{
    public class AuthentcationService(UserManager<ApplicationUser> userManager ,IConfiguration configuration , IMapper mapper) : IAuthentacationService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {

//Check If email Exist
var User= await userManager.FindByEmailAsync(loginDto.Email);

            if (User is null)
            { 
                throw new UserNotFoundEx(loginDto.Email);
            }
          
            //Check Password
            var IsPasswordValid = await userManager.CheckPasswordAsync(User, loginDto.Password);

            if (IsPasswordValid)
            {
                //ReturnDto
                return new UserDto()
                {
                    DisplayName = User.DisplayName,
                    Email = User.Email,
                    Token = await CreateTokenAsync(User)
                };
            }
            else 
            {
                throw new UnauthorizedException();
            }





        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
        new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
        new Claim(ClaimTypes.NameIdentifier, user.Id ?? string.Empty)
    };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = configuration["JwtOptions:secretKey"]
                      ?? throw new InvalidOperationException("JWT secretKey is missing!");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtOptions:issuer"],
                audience: configuration["JwtOptions:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            //Mapping from registerDto to  Application user


            var User = new ApplicationUser()
            {
                 Email = registerDto.Email,
                 DisplayName= registerDto.DisplayName,
                 PhoneNumber = registerDto.PhoneNumper,
                 UserName = registerDto.UserName,


            };

            // Check if user already exists
            var existingUser = await userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                var errors = new List<string> { "Email already exists" };
                throw new BadRequestExpection(errors);
            }

            //Create User  
            var Result = await userManager.CreateAsync(User, registerDto.Password);

            if (Result.Succeeded)
            {
                return new UserDto()
                {
                    DisplayName = User.DisplayName,
                    Email = User.Email,
                    Token = await CreateTokenAsync(User)
                };
            }
            else
            {
                var Errors = Result.Errors.Select(E => E.Description).ToList();
                throw new BadRequestExpection(Errors);
            }







            }















        public async Task<bool> CheckEmailAsync(string email)
        {
            var User =  await userManager.FindByEmailAsync(email);
            if (User is null)
            {


                return false;

            }
            else return true;


        }





        public async Task<AddressDto> GetAddressAsync(string email)
        {
            var User = await userManager.Users.Include(U => U.Address)
                .FirstOrDefaultAsync(U =>U.Email == email) ?? throw new UserNotFoundEx(email);
           
                if(User.Address is not null)
            {
                return mapper.Map<Address,AddressDto>(User.Address);


            }
            else { throw new AddressNotFoundEx(User.UserName); }




        }

        public async Task<AddressDto> UpdateAddressAsync(string email, AddressDto addressDto)
        {





            var User = await userManager.Users.Include(U => U.Address)
    .FirstOrDefaultAsync(U => U.Email == email) ?? throw new UserNotFoundEx(email);

            if (User.Address is not null)
            {
                //Update
                User.Address.FristName= addressDto.FristName;
                User.Address.LastName= addressDto.LastName;
                User.Address.Street = addressDto.Street;

                User.Address.City= addressDto.City;
                User.Address.Country = addressDto.Country;



            }
            else
            {
                //Add New Address

                User.Address = mapper.Map<AddressDto, Address>(addressDto);

            }

            await userManager.UpdateAsync(User);




            return mapper.Map<AddressDto>(User.Address);





        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var User = await userManager.FindByEmailAsync(email) ?? throw new UserNotFoundEx(email);
            return new UserDto()
            {
                DisplayName=User.DisplayName,
                Email =User.Email,

                Token=await CreateTokenAsync(User)  

            };



        }
    }
}
