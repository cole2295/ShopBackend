﻿using System;

namespace Shop.Api.Models.Request.User
{
    public class ResetPasswordRequest
    {
        public string Password { get; set; }
        public string Mobile { get; set; }
    }
}