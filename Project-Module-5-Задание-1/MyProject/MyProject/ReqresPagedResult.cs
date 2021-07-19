using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class ReqresPagedResult<T>
    {
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
