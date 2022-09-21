public interface IGeneratorProvider<in TGenerator, out TData>
{
    TData GetGenerationData();
    void ConfigureGenerator(TGenerator generator);
}
