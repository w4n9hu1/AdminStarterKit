﻿namespace AdminStarterKit.Api.Contracts
{
    public class LoginRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
