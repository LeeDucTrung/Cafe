namespace VPDT.Data
{
    public interface IDbContextFactory<T>
    {
        T GetContext();
    }
}
