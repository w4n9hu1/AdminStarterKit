﻿using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Enums;

namespace AdminStarterKit.Application
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

        string GenerateRefreshToken(User user);
    }
}
