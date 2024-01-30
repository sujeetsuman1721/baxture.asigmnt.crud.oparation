using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baxture.asigmnt.crud.oparation.domain.Models
{
    public class RegisterUser
    {
     
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;

  
        public int Age { get; set; }

        public IList<String> Hobbies { get; set; }
    }
}
