using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace baroudeurs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Date)]
        public DateTime AccountCreation { get; set; }
        public DateTime LastConnection { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<Discovery> Discoveries { get; set; }
    }
}