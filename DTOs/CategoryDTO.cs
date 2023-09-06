﻿using EcommerceOfficial.Entities;

namespace EcommerceOfficial.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
