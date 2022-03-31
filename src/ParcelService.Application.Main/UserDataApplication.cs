using AutoMapper;
using ParcelService.Application.DTO;
using ParcelService.Application.Interface;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Entity;
using ParcelService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Application.Main
{
    public class UserDataApplication : IUserDataApplication
    {
        private readonly IUserDataDomain _userDataDomain;
        private readonly IMapper _mapper;

        public UserDataApplication(IUserDataDomain userDataDomain, IMapper mapper)
        {
            _userDataDomain = userDataDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(UserDataDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<UserData>(userDataDto);
                response.Data = _userDataDomain.Insert(userData);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(UserDataDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<UserData>(userDataDto);
                response.Data = _userDataDomain.Update(userData);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(string userDataId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _userDataDomain.Delete(userDataId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<UserDataDto> Get(string userDataId)
        {
            var response = new Response<UserDataDto>();
            try
            {
                var userData = _userDataDomain.Get(userDataId);
                response.Data = _mapper.Map<UserDataDto>(userData);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<UserDataDto>> GetAll()
        {
            var response = new Response<IEnumerable<UserDataDto>>();
            try
            {
                var userData = _userDataDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<UserDataDto>>(userData);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(UserDataDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<UserData>(userDataDto);
                response.Data = await _userDataDomain.InsertAsync(userData);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(UserDataDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<UserData>(userDataDto);
                response.Data = await _userDataDomain.UpdateAsync(userData);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string userDataId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _userDataDomain.DeleteAsync(userDataId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<UserDataDto>> GetAsync(string userDataId)
        {
            var response = new Response<UserDataDto>();
            try
            {
                var userData = await _userDataDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<UserDataDto>(userData);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<UserDataDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UserDataDto>>();
            try
            {
                var userData = await _userDataDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<UserDataDto>>(userData);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion
    }
}