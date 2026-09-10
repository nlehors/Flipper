using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    public Vector3 force;
    public float strength = 100;
    void OnCollisionEnter(Collision collision)
    {
        force=-collision.contacts[0].normal*strength;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
