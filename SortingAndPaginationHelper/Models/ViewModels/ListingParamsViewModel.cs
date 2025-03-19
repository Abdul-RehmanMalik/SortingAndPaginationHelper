namespace SortingAndPaginationHelper.Models.ViewModels
{
    public class ListingParamsViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByColumn { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }

    }
}
