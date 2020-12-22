using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Models.Account
{
    public class UserModel
    {
        public uint User_seq { get; set; }
        public string User_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void ConvertPassword()
        {
            var sha = new System.Security.Cryptography.HMACSHA512();
            sha.Key = System.Text.Encoding.UTF8.GetBytes(this.Password.Length.ToString());

            var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.Password));

            this.Password = Convert.ToBase64String(hash);
        }

        internal UserModel GetLoginUser()
        {
            string sql = @"
            SELECT
                user_seq,
	            user_name, 
	            email, 
	            password
            FROM
                t_user
            WHERE
                user_name = @User_name
            ";

            UserModel user;

            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=akworjs5394@"))
            {
                conn.Open();

                user = Dapper.SqlMapper.QuerySingleOrDefault<UserModel>(conn, sql, this);
            }

            if (user == null) throw new Exception("사용자가 존재하지않습니다.");

            if (user.Password != this.Password) throw new Exception("비밀번호가 일치하지않습니다.");

            return user;
        }

        internal int Register()
        {
            string sql = @"
            INSERT INTO t_user (
	            user_name, 
	            email, 
	            password
            ) VALUES (
                @User_name,
                @Email,
                @Password
	        )
            ";

            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=akworjs5394@"))
            {
                conn.Open();

                return Dapper.SqlMapper.Execute(conn, sql, this);
            }
        }
    }
}
