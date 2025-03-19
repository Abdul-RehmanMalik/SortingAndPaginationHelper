# SortingAndPaginationHelper

**SortingAndPaginationHelper** is a lightweight and efficient **.NET library** designed to simplify **sorting, searching, and pagination** for **Entity Framework Core (EF Core)** queries. This library provides a reusable helper function that dynamically applies sorting, searching, and pagination based on request parameters, making it easy to implement optimized API responses.

## 🚀 Features  
✅ **Dynamic Sorting & Pagination** – Sort by any column dynamically.  
✅ **EF Core Integration** – Works seamlessly with `IQueryable<T>`.  
✅ **Search Support** – Enables filtering records based on a search term.  
✅ **Flexible Sorting Orders** – Supports ascending and descending sorting.  
✅ **Efficient Pagination** – Uses `Skip()` and `Take()` for performance optimization.  
✅ **Easy to Integrate** – Minimal setup required, making it developer-friendly.  

---

## 📦 Installation  

Install the NuGet package:  

```sh
dotnet add package PaginationHelper
```
Or via the NuGet Package Manager in Visual Studio:
```sh
Manage NuGet Packages -> Browse -> Search "PaginationHelper" -> Install
```

📖 Usage
🔹 1. Add Pagination & Sorting to a Query
Use ApplyListSortingAndPaginationAsync to paginate and sort your data dynamically.
```sh
public async Task<ResponseViewModel> GetUsersAsync(ListingParamsViewModel listingParams)
{
    IQueryable<ApplicationUser> userQuery = dbContext.Users;

    // Apply search filtering
    if (!string.IsNullOrEmpty(listingParams.Search))
    {
        userQuery = userQuery.Where(u => u.FirstName.Contains(listingParams.Search)
                                      || u.LastName.Contains(listingParams.Search)
                                      || u.Email.Contains(listingParams.Search));
    }

    // Apply sorting and pagination
    PagedDataViewModel<ApplicationUser> paginatedUsers =
        await paginationHelper.ApplyListSortingAndPaginationAsync(userQuery, listingParams);

    return new ResponseViewModel(StatusCodes.Status200OK, "Users fetched successfully", paginatedUsers);
}
```
🔹 2. Define Pagination and Sorting Parameters
Use the ListingParamsViewModel to define page number, page size, sorting column, order, and search filter.
```sh
var listingParams = new ListingParamsViewModel
{
    Page = 1,
    PageSize = 10,
    OrderByColumn = "FirstName",
    OrderBy = SortingOrders.Ascending,
    Search = "John"
};
```
 3. Response Structure
The function returns a PagedDataViewModel<T>, containing the paginated records and total record count.
```sh
public class PagedDataViewModel<T> where T : class
{
    public List<T> Records { get; set; }
    public int TotalRecords { get; set; }
}
```
API Integration Example
Here’s how you can use PaginationHelper in a .NET API Controller:
```sh
[HttpGet("users")]
public async Task<IActionResult> GetUsers([FromQuery] ListingParamsViewModel listingParams)
{
    var response = await _userService.GetUsersAsync(listingParams);
    return Ok(response);
}
```
## 🏆 Why Use PaginationHelper?
✅ **Reduces Boilerplate Code** - Eliminates redundant pagination & sorting logic.

✅ **Performance Optimization** - Paginates large datasets efficiently using EF Core.

✅ **Highly Maintainable** - Centralizes sorting, filtering, and pagination logic.

✅ **Easy to Integrate** - Minimal setup required in new or existing projects.

## 👥 Contributing  
Contributions are welcome! Feel free to submit pull requests or report issues.  
### Steps to Contribute:  
1. **Fork** the repository.  
2. **Create a new branch** (`feature-branch`).  
3. **Commit your changes** with a meaningful message.  
4. **Push to your fork**.  
5. **Submit a Pull Request (PR)** 🚀.  

We appreciate your contributions! 🎉

## 📄 License
This project is licensed under the MIT License.

## ⭐ Support the Project
If you find this useful, give it a ⭐ star on GitHub!

## 📬 Contact

📧 Author's Email: abdulrehmanmalikofficial2@gmail.com

🌐 Company Website: [Tekulse](https://tekulse.com)

📧 Support Email: contact@tekulse.com
