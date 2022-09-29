using Zenject;

public abstract class DIFactory<T> : IFactory<T>
{
    protected DiContainer _container;

    protected DIFactory(DiContainer container)
    {
        _container = container;
    }

    public abstract T Create(T prefab);
}
