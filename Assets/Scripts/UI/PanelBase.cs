using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PanelBase : MonoBehaviour
{
    protected virtual void Start()
    {
        ClosePanel();
    }

    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
        PauseManager.Pause();
    }

    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
        PauseManager.Continue();
    }

    public void ReturnToMenu()
    {
        PauseManager.Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    [Serializable]
    public class TextField
    {
        [SerializeField] private string _placeholder;
        [SerializeField] private TextMeshProUGUI _textDisplay;

        public void ChangeText(string value)
        {
            _textDisplay.text = string.Format(_placeholder, value);
        }
    }
}
