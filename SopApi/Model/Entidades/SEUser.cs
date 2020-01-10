using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Int16 ProfileId { get; set; }
        public byte RolId { get; set; }
        public bool Active { get; set; }
        public Int16 ApplicationId { get; set; }
        public string RolName { get; set; }
    }
}
