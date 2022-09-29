using UnityEngine;
using Zenject;

public class InteractiveObjectFactory : DIFactory<GameObject>
{
    public InteractiveObjectFactory(DiContainer container) : base(container)
    {
    }

    public override GameObject Create(GameObject prefab)
    {
        return _container.InstantiatePrefab(prefab);
    }
}
