public interface IConfigurable<in TData>
{
    void Configure(TData value);
}
