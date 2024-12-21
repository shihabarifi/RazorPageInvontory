using System;

namespace RazorPageInvontory.Modules.UsersSys.Models
{
    public class RefreshToken
    {
        public string? Token {get;set;}
        public string? JWTToken { get;set; }
        public DateTime Created {get;set;}
        public DateTime Expires {get;set;}
    }
}