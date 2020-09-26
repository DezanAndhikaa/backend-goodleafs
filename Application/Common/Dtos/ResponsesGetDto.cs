using System.Collections.Generic;

namespace Application.Common.Dtos {
    public class ResponsesGetDto<T> {

        public ResponsesGetDto (int totalData, int page, List<T> data) {
            this.TotalData = totalData;
            this.TotalPagination = totalData / 10 == 0 ? 0 : totalData / 10;
            this.NextPage = this.TotalPagination <= page ? 0 : page + 1;
            this.PrevPage = page <= 1 ? 0 : page - 1;
            this.Data = data;
        }

        public int TotalData { get; set; }
        public int TotalPagination { get; set; }
        public int NextPage { get; set; }
        public int PrevPage { get; set; }

        public List<T> Data { get; set; }

    }
}