﻿namespace E_CommerceClient.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}