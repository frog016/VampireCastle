using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] protected Text _text;

    public void ChangeText(int number) => ChangeText(number.ToString());

    public virtual void ChangeText(string text)
    {
        if (_text == null)
            return;

        _text.text = text;
    }
}
