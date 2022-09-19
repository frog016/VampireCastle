using System;
using System.Linq;

public class ItemBag
{
    private readonly IUsableItem[] _items;

    public ItemBag(IUsableItem[] items)
    {
        _items = items;
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
