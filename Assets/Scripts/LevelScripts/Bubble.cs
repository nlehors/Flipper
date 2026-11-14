using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector3 force;
    public float strength = 1;
    public Animation animation;

    void OnCollisionEnter(Collision collision)
    {
        force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
        
    }
}
