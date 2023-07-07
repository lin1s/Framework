using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class AuthHelper
    {
        /// <summary>
        /// 创建token
        /// </summary>
        /// <returns></returns>
        public static string CreateJwtToken(IDictionary<string, object> payload, string secret, IDictionary<string, object> extraHeaders = null)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret);
            return token;
        }

        /// <summary>
        /// 校验解析token
        /// </summary>
        /// <returns></returns>
        public static string ValidateJwtToken(string token, string secret)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm alg = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, alg);
                var json = decoder.Decode(token, secret, true);
                //校验通过，返回解密后的字符串
                return json;
            }
            catch (TokenExpiredException)
            {
                //表示过期
                return "expired";
            }
            catch (SignatureVerificationException)
            {
                //表示验证不通过
                return "invalid";
            }
            catch (Exception)
            {
                return "error";
            }
        }


        //-------------客户端调用---------------
        public static void Main(string[] args)
        {
            var sign = "123";
            var extraHeaders = new Dictionary<string, object>
                     {
                        { "myName", "limaru" },
                    };
            //过期时间(可以不设置，下面表示签名后 10秒过期)
            double exp = (DateTime.UtcNow.AddSeconds(10) - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new Dictionary<string, object>
                     {
                         { "userId", "001" },
                         { "userAccount", "fan" },
                         { "exp",exp }
                      };
            var token = CreateJwtToken(payload, sign, extraHeaders);
            var text = ValidateJwtToken(token, sign);
            Console.ReadKey();
        }
    }
}
