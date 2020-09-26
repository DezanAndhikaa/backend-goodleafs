using System.Collections.Generic;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class OpeningDataDto {
        public List<ProductsDto> DealoftheDay { get; set; }
        public List<Category> Category { get; set; }
        public List<ArticlesOpeningDto> Articles { get; set; }
        public List<CategoryProductDto> EtalaseList { get; set; }
    }
}