using Microsoft.EntityFrameworkCore;
using SortingAndPaginationHelper.Constants;
using SortingAndPaginationHelper.Models.ViewModels;
using System.Linq.Expressions;

namespace SortingAndPaginationHelper
{
    public class PaginationHelper
    {
        public async Task<PagedDataViewModel<T>> ApplyListSortingAndPaginationAsync<T>(
            IQueryable<T> listQuery, ListingParamsViewModel listingParamsViewModel) where T : class
        {
            PagedDataViewModel<T> pagedDataViewModel = new PagedDataViewModel<T>();

            if (PropertyExists<T>(listingParamsViewModel.OrderByColumn))
            {
                ParameterExpression entity = Expression.Parameter(typeof(T));
                MemberExpression property = Expression.PropertyOrField(entity, listingParamsViewModel.OrderByColumn);
                Expression<Func<T, object>> expression = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), entity);

                if (listingParamsViewModel.OrderBy == SortingOrders.Ascending)
                    listQuery = listQuery.OrderBy(expression);
                else if (listingParamsViewModel.OrderBy == SortingOrders.Descending)
                    listQuery = listQuery.OrderByDescending(expression);
            }

            pagedDataViewModel.TotalRecords = await listQuery.CountAsync();
            listQuery = listQuery.Skip((listingParamsViewModel.Page - 1) * listingParamsViewModel.PageSize).Take(listingParamsViewModel.PageSize);
            pagedDataViewModel.Records = await listQuery.ToListAsync();

            return pagedDataViewModel;
        }
private bool PropertyExists<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName) != null;
        }
    }

}
