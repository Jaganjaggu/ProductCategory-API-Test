﻿using System.ComponentModel.DataAnnotations;

namespace ProductCategoryAPI.Models.DTO
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
