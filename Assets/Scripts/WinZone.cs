using UnityEngine;

public class WinZone : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        gameManager.GameWin();
    }
}
