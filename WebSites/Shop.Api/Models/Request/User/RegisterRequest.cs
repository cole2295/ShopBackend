﻿using System;

namespace Shop.Api.Models.Request.User
{
    /// <summary>
    ///  请求DTO
    /// </summary>
    public class RegisterRequest
    {
        public Guid ParentId { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string MsgCode { get; set; }
        public string Token { get; set; }
        
    }
}