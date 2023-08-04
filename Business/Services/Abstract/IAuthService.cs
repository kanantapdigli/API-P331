using Business.DTOs.Auth.Request;
using Business.DTOs.Auth.Response;
using Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<Response> RegisterAsync(AuthRegisterDTO model);
        Task<Response<AuthLoginResponseDTO>> LoginAsync(AuthLoginDTO model);
    }
}
