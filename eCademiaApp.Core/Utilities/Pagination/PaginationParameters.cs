namespace eCademiaApp.Core.Utilities.Pagination
{
    public abstract class PaginationParameters
    {
        const int maxPageSize = 12;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 3;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
