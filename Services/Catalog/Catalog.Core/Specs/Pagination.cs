namespace Catalog.Core.Specs;

public class Pagination<T> where T : class
{
    public Pagination()
    {
        
    }
    public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }

    private int PageIndex;
    private int PageSize;
    private int Count;
    private IReadOnlyList<T> Data;
}
