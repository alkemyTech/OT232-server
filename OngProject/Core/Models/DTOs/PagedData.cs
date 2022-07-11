using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs
{
    public class PagedData<T> where T : class
    {
        public PagedData(T items,int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            NextPage = (HasNext) ? $"https://localhost:5001/api/News?Page={pageNumber + 1}" : string.Empty;
            PreviousPage = (HasPrevious) ? $"https://localhost:5001/api/News?Page={pageNumber - 1}" : string.Empty;
        }
        
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public string PreviousPage { get; private set; }
        public string NextPage { get; private set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);
        public T Items { get; private set; }
    }
}
