using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int lifeCount = 3;
    public TextMeshProUGUI lifeCountText;
    public TextMeshProUGUI gameWinText;
    public Transform spawnPosition;

    void Start()
    {
        SpawnBall();
        RefreshLifeCountText();
    }
   public void LoseLife()
    {
        Debug.Log("Lose Life");

        lifeCount -= 1;

        if (lifeCount > -1)
        {
            SpawnBall();
            RefreshLifeCountText();
        }
        else
        {
            lifeCountText.text = "GAME OVER!";
        }
        
        
    }

   public void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);
    }

    void RefreshLifeCountText()
    {
        lifeCountText.text = lifeCount.ToString() + " Lives Remaining!";
    }

    public void GameWin()
    {
    }
}
