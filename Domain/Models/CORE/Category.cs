﻿namespace RetailEcommerce.Domain.Models.Core
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false; 
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
