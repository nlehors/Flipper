using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Vector3 force;
    public float strength = 1;
    public Animation animation;
    public int pointsValue = 100;
    
    void OnCollisionEnter(Collision collision)
    {
        force=(collision.transform.position - transform.position).normalized*strength;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);

        animation.Play();
        ScoreManager.instance.GainPoints(100);
    }
}
