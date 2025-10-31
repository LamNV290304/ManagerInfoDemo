using System;
using System.Collections.Generic;
using ManagerInfoDemo.Models;

namespace ManagerInfoDemo.ViewModels
{
    public class CustomerListResult
    {
        public IReadOnlyList<Customer> Items { get; init; } = Array.Empty<Customer>();
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalItems { get; init; }
        public string? Keyword { get; init; }
        public bool? IsVerify { get; init; }

        public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
