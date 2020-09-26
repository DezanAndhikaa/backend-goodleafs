using System.Collections.Generic;

namespace Application.Common.Dtos {
    public class CategoryProductDto {
        public string CategoryName { get; set; }
        public List<ProductsDto> Products { get; set; }
    }
}