using UnityEngine;
using Zenject;

public abstract class ComponentConfigurator<TComponent, TData> : ScriptableObject, IConfigurable<TData> where TComponent : IConfigurable<TData>
{
    private TComponent _configurableComponent;

    [Inject]
    public void Initialize(TComponent component)
    {
        _configurableComponent = component;
    }

    public void Configure(TData value)
    {
        _configurableComponent.Configure(value);
    }
}
