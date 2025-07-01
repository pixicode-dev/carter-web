namespace CARTER.Models.Common
{
    public class PagingRequestBase
    {
        public string Search { get; set; }
        //[DefaultValue(1)]
        public int? PageIndex { get; set; }
        //[DefaultValue(50)]
        public int? PageSize { get; set; }
        public PagingRequestBase()
        {
            //PageIndex = 1;
            //PageSize = 50;
        }
    }
}
