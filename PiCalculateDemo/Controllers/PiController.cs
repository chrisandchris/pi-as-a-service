using Microsoft.AspNetCore.Mvc;

namespace PiCalculateDemo.Controllers
{
    [ApiController]
    public class PiController : ControllerBase
    {
        // GET api/values
        [HttpGet("/api/pi/{length}")]
        public ActionResult<string> Get(int length)
        {
            return CalculatePi(length);
        }

        public static string CalculatePi(int digits)
        {
            digits++;

            var x = new uint[digits * 10 / 3 + 2];
            var r = new uint[digits * 10 / 3 + 2];

            var pi = new uint[digits];

            for (var j = 0; j < x.Length; j++)
            {
                x[j] = 20;
            }

            for (var i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (var j = 0; j < x.Length; j++)
                {
                    var num = (uint)(x.Length - j - 1);
                    var dem = num * 2 + 1;

                    x[j] += carry;

                    var q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }


                pi[i] = (x[x.Length - 1] / 10);


                r[x.Length - 1] = x[x.Length - 1] % 10; ;

                for (var j = 0; j < x.Length; j++)
                {
                    x[j] = r[j] * 10;
                }
            }

            var result = "";

            uint c = 0;

            for (var i = pi.Length - 1; i >= 0; i--)
            {
                pi[i] += c;
                c = pi[i] / 10;

                result = pi[i] % 10 + result;
            }

            return result;
        }
    }
}