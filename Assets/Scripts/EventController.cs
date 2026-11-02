using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent;
    [SerializeField] UnityEvent onTriggerExitEvent;
    [SerializeField] UnityEvent onCollisionEnterEvent;
    [SerializeField] UnityEvent onCollisionExitEvent;
    [SerializeField] UnityEvent onDestroy;
    [SerializeField] public int wallLife;
 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        onTriggerEnterEvent.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        onTriggerExitEvent.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        onCollisionEnterEvent.Invoke();
        wallLife--;
        OnDestroy();
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
        onCollisionExitEvent.Invoke();
    }
    
    void OnDestroy()
    {
        if (wallLife < 1)
        {
            onDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}