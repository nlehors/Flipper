using UnityEngine;

public class BubbleSpawner : MonoBehaviour

{
    public GameObject bubble;
    public Transform ball;
    
    void OnTriggerEnter(Collider other)
    {        if (!other.CompareTag("Bubble") && !other.CompareTag("Bumper") && !other.CompareTag("Paddle"))
        {
            Instantiate(bubble, ball.position, Quaternion.Euler(0, 0, 90));
        }

    }
    

}