﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
