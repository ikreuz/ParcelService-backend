using AutoMapper;
using ParcelService.Application.DTO;
using ParcelService.Application.Interface;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Interface;
using System;

namespace ParcelService.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly IPortalSecurity _portalSecurity;
        //private readonly IEncrypt _encrypt;

        public UsersApplication(
            IUsersDomain usersDomain, 
            //IEncrypt encrypt,
            IMapper mapper, 
            IPortalSecurity portalSecurity)
        {
            _usersDomain = usersDomain;
            //_encrypt = encrypt;
            _mapper = mapper;
            _portalSecurity = portalSecurity;
        }

        public Response<UsersDto> Authenticate(string username, string passwrod)
        {
            var response = new Response<UsersDto>();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwrod))
            {
                response.Message = "Parameters cannot be empty";
                return response;
            }

            string strUserName = _portalSecurity.InputFilter(username,
                FilterFlag.NoScripting |
                FilterFlag.NoSQL |
                FilterFlag.Nomarkup |
                FilterFlag.MultiLine);

            try
            {
                var user = _usersDomain.Authenticate(strUserName);
                
                if (user != null && !string.IsNullOrEmpty(user.Password))
                {


                    response.Data = _mapper.Map<UsersDto>(user);
                    response.IsSuccess = true;
                    response.Message = "Successful Authentication!";
                }
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "User doesn't exist";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

    }
}
