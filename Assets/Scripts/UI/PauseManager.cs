using UnityEngine;

public class PauseManager
{
    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Continue()
    {
        Time.timeScale = 1f;
    }
}
