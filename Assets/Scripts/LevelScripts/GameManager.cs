using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int lifeCount = 3;
    public TextMeshProUGUI lifeCountText;
    public TextMeshProUGUI gameWinText;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    public Transform spawnPosition4;

    public int level = 1;

    void Start()
    {
        level = 1;
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
        if (level == 1)
        Instantiate(ballPrefab, spawnPosition1.position, Quaternion.identity);
        else if (level == 2)
        Instantiate(ballPrefab, spawnPosition2.position, Quaternion.identity);
        else if (level == 3)
        Instantiate(ballPrefab, spawnPosition3.position, Quaternion.identity);
    }

    void RefreshLifeCountText()
    {
        lifeCountText.text = lifeCount.ToString() + " Lives Remaining!";
    }

    public void GameWin()
    {
    }

    public void ChangeLevel()
    {
        level++;
    }
}
