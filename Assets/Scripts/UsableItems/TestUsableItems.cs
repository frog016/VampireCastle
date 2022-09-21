using UnityEngine;
using Zenject;

public class TestUsableItems : MonoBehaviour
{
    private IUsableItem[] _items;

    [Inject]
    public void Initialize(IUsableItem[] items)
    {
        _items = items;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _items[0].Use();
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _items[1].Use();
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _items[2].Use();
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
            _items[3].Use();
    }
}
