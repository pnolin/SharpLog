﻿using SharpLog.Security.Core.Models;
using System.Threading.Tasks;

namespace SharpLog.Security.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AccessTokens> GetAccessTokenAsync(FetchAccessTokens accessTokenFetchInformation);
    }
}