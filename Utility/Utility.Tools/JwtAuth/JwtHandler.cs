using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Utility.Tools.General;

namespace Utility.Tools.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly JwtOptions _options;
        private readonly SecurityKey _issuerSigninKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            _options = options.Value;
            _issuerSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigninKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = _options.Issuer,
                IssuerSigningKey = _issuerSigninKey//,
                //ValidateLifetime = true,
                //LifetimeValidator = LifetimeValidator,
                //RequireExpirationTime = true

            };
        }
        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)
        {
            Console.WriteLine("*************************************************************");
            Console.WriteLine(expires);
            if (expires != null)
            {
                return expires > DateTime.Now;
            }
            return false;
        }
        public JsonWebToken Create(Guid userId)
        {

            var expire = DateTime.Now.AddMinutes(_options.ExpiryMinutes).ToUnix();
            var now = DateTime.Now.ToUnix();// (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);

            var payload = new JwtPayload
            {
                {"sub", userId},
                { "iss",_options.Issuer},
                { "iat",now},
                { "exp",expire},
                { "unique_name",userId}

            };
            //"roles": ["Admin", "SuperUser"]

            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken
            {
                Expires = expire,
                Token = token
            };
        }
        public JsonWebToken CreateToken(Guid userId,List<string> roles)
        {

            var expire = DateTime.Now.AddMinutes(_options.ExpiryMinutes).ToUnix();
            var now = DateTime.Now.ToUnix();// (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);

            var payload = new JwtPayload
            {
                {"sub", userId},
                { "iss",_options.Issuer},
                { "iat",now},
                { "exp",expire},
                { "unique_name",userId},
                { "roles", roles}

            };
            //"roles": ["Admin", "SuperUser"]

            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken
            {
                Expires = expire,
                Token = token
            };
        }
    }
}
