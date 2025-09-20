using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DaraTransferObject.IdentityDtos;
using Shared.DaraTransferObject.IdentiyDto;

namespace ServiceAbstraction
{
    public interface IAuthentacationService
    {

        //login

        //This EndPoint Will Handle User Login Take Email and Password Then Return Token ,  Email and DisplayName To Client  
        Task<UserDto> LoginAsync(LoginDto loginDto);

        //register

        //This EndPoint Will Handle User Registration Will Take Email , Password  , UserName , Display Name And Phone Number Then Return Token , Email and Display Name To Client  
        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        //Module Check Email Endpoint
        //This EndPoint Will Handle Checking if User Email Is Exists Or Not Will Take Email Then Return boolean To Client  

        Task<bool> CheckEmailAsync(string email);







        //Module Get Current User Address Endpoint
        //EndPoint Will Take Email Then Return Address of Current Logged in User To Client  


        Task<AddressDto> GetAddressAsync(string email);








        //Module Update Current User Address Endpoint
        //EndPoint Will Handle Updating User Address Take Updated Address and Email Then Return Address after Update To Client  




        Task<AddressDto> UpdateAddressAsync(string email, AddressDto addressDto);





        //Module Get Current User Endpoint
        //EndPoint Will Take Email Then Return Token , Email and Display Name To Client  




        Task<UserDto> GetCurrentUserAsync(string email);




    }
}
