﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;


    public class Catagory
    {
        //want to make it as a primary key

        [Key]
        public int Id { get; set; }

        // must be filled
        
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage="Display Order must be between 1 to 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; 
    }
