namespace SortingAndPaginationHelper.Models.ViewModels
{
    public class PagedDataViewModel<T> where T : class
    {
        public List<T> Records { get; set; }
        public int TotalRecords { get; set; }
    }
}
