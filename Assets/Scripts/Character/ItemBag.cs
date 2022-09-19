using System;
using System.Linq;
using UnityEngine;

public class ItemBag : MonoBehaviour
{
    private IUsableItem[] _items;

    private void Awake()
    {
        _items = GetComponentsInChildren<IUsableItem>();
    }

    public void UseItem<T>() where T : IUsableItem
    {
        UseItem(typeof(T));
    }

    public void UseItem(Type itemType)
    {
        _items.FirstOrDefault(item => item.GetType() == itemType)?.Use();
    }
}
