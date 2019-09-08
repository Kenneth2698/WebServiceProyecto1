using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebServiceProyecto1.Models;

namespace WebServiceProyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { Base64Encode("880316"), "value2" };
        }



        [HttpPost("GetCode")]
        public Answer GetCode([FromBody]Provider p)
        {
            Answer ans = new Answer();


            Random random = new Random();

            string code = "" + random.Next(1000, 1000000);

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres; Password=1234;Database=Principal;");
            conn.Open();

            string sql = $"SELECT * FROM createProvider('{p.Id}','{p.Name}','{p.Address}')";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);

            command.ExecuteScalar();

            conn.Close();

            conn.Open();
            sql = $"SELECT * FROM saveCode('{p.Id}','{Base64Encode(code)}','{0}')";
            command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
                ans.Code = dr["CODE"].ToString();

            conn.Close();


            return ans;

        }

        public static string Encrypt(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string Decrypt(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



    }
}
