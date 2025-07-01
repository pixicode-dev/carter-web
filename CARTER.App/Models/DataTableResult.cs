using Newtonsoft.Json;
using System.Collections.Generic;

namespace CARTER.App.Models
{
    [JsonObject(Title = "result")]
    public class DataTableResult<T>
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("data")]
        public List<T> Data { get; set; }

        public DataTableResult(int Draw, int RecordsTotal, int RecordsFiltered, List<T> Data)
        {
            if (Data == null)
            {
                Data = new List<T>();
            }

            this.Draw = Draw;
            this.RecordsTotal = RecordsTotal;
            this.RecordsFiltered = RecordsFiltered;
            this.Data = Data;
        }
    }
}
