namespace Application.Common.Dtos {
    public class ProductRequestDto {
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public string CategoryName { get; set; }
        public int Cost { get; set; }
        public string BaseColor { get; set; }
        public bool IsAvailable { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
    }
}