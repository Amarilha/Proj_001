using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_NET_wpf.Models
{
    public class UserModel
    {
        internal string Username;

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public static implicit operator UserModel(UserModel v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
