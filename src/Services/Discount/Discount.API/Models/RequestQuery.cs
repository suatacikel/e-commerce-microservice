namespace Discount.API.Models
{
    public class RequestQuery
    {
        public string WhereClause { get; set; } = "";
        public int Limit { get; set; } = 5;
        public int Skip { get; set; } = 0;
    }
}
