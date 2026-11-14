using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void ChangeFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
