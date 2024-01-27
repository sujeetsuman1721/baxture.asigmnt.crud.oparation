using System.ComponentModel.DataAnnotations;

namespace baxture.asigmnt.crud.oparation.Model
{
    public class RegisterUser
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;

        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets Hobbies.
        /// </summary>
        [Required]
        public IList<String> Hobbies { get; set; }
    }
}
