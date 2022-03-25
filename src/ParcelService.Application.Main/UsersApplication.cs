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

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDto> Authenticate(string username, string passwrod)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwrod))
            {
                response.Message = "Parameters cannot be empty";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Successful Authentication!";
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
