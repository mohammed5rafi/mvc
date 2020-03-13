using System.ComponentModel.DataAnnotations;
namespace MODEL
{
    public class Login
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$", ErrorMessage = "Invalid username")]
        public string LUsername { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]

        public string LPassword { get; set; }

        public class SignUp
        {
            [Required]
            [RegularExpression(@"^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$", ErrorMessage = "Invalid username")]
            public string SUsername { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]

            public string Password { get; set; }
            public string FirstName { get; set; }


            public string LastName { get; set; }
            public string SPassword { get; set; }

            public string SConfirmPassword { get; set; }
            public string EmailId { get; set; }
            public string Dob { get; set; }

            public int ciPerDistrict { get; set; }
            public string ciPerStateName { get; set; }


            public string ciPerCountryName { get; set; }
            [MaxLength(10)]
            public int PhoneNumber { get; set; }


            public int UserGender { get; set; }




            [MaxLength(250)]
            public string pidocFileDes { get; set; }
            public string pidocFileName { get; set; }
            public string pidocExtension { get; set; }

            public string pidDocDelStatus { get; set; }

            public byte[] pidocFile { get; set; }

        }
    }


    public class State
    {
        public int stCode { get; set; }
        public string stName { get; set; }
        public int ctyCode { get; set; }
        public string ctyName { get; set; }

    }

}







