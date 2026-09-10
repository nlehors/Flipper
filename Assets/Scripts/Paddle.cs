using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float targetPosition = 75;
    public float originPosition;

    public HingeJoint hinge;

    public KeyCode pressKey = KeyCode.Space;

    JointSpring jointSpring;
    
    void Start()
    {
        jointSpring = hinge.spring;
    }
    
    void Update()
    { 
        if (Input.GetKey(pressKey)) 
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hinge.spring = jointSpring;

    }
}