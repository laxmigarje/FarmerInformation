using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerInformation.Models
{
    [Table("Farmer")]
    public class Farmer
    {
       
       
        
            [Key]
            [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First_name is required")]
            
            public string First_name { get; set; }

            [Required(ErrorMessage = "Middle_name is required")]
            public string Middle_name { get; set; }

            [Required(ErrorMessage = "Last_name is required")]
            public string Last_name { get; set; }

            [Required(ErrorMessage = "mobile_no is required")]
            public string mobile_no { get; set; }

            [Required(ErrorMessage = "Addhar_no is required")]
            public string Addhar_no { get; set; }

            [Required(ErrorMessage = "Farmer_Address is required")]
            public string Farmer_Address { get; set; }

            [Required(ErrorMessage = "District_name is required")]

            public string District_name { get; set; }

            [Required(ErrorMessage = "Taluka_name is required")]
            public string Taluka_name { get; set; }

            [Required(ErrorMessage = "Village_name is required")]
            public string Village_name { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public int Password { get; set; }

















        }

    }
    


