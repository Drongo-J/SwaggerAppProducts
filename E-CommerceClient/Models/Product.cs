namespace E_CommerceClient.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
