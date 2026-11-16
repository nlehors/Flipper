using UnityEngine;
using UnityEngine.Serialization;
using System;
using PrimeTween;

public class ColliderFixes : MonoBehaviour
{
    [FormerlySerializedAs("obstaclelayers")]
    public LayerMask obstacleLayers;
    public Color mtvColor = Color.yellow;
    public bool autoResolve = true;
    public bool smoothResolve = true;
    public float resolveSpeed = 10f;

    public event Action<Vector3> OnPenetrationStart;
    public event Action<Vector3> OnPenetrationStay;
    public event Action OnPenetrationEnd;

    private Collider col;
    private Camera cam;
    private Vector3 lastCorrection;
    private bool resolvingCollision;

    void Start()
    {
        col = GetComponent<Collider>();
        cam = Camera.main;

        OnPenetrationStart += correction =>
        {
            float depth = correction.magnitude;
            Debug.Log($"Started penetration, MTV = {depth:F3}");
            if (cam != null)
                Tween.ShakeCamera(cam, strengthFactor: depth * 2f, duration: 0.3f, frequency: 10f);
        };
        OnPenetrationEnd += () => Debug.Log("Penetration resolved.");
    }

    void Update()
    {
        bool colliding = col.GetPenetrationsInLayer(obstacleLayers, out Vector3 correction);
        correction += correction.normalized * 0.001f;
        lastCorrection = colliding ? correction : Vector3.zero;

        if (colliding)
        {
            if (!resolvingCollision) OnPenetrationStart?.Invoke(correction);
            else OnPenetrationStay?.Invoke(correction);
            resolvingCollision = true;

            if (autoResolve)
            {
                Vector3 delta = smoothResolve
                    ? correction * (1f - Mathf.Exp(-resolveSpeed * Time.deltaTime))
                    : correction;
                transform.position += delta;
            }
        }
        else
        {
            if (resolvingCollision) OnPenetrationEnd?.Invoke();
            resolvingCollision = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (col == null) col = GetComponent<Collider>();
        if (col == null) return;

        if (lastCorrection != Vector3.zero)
        {
            Vector3 start = col.bounds.center;
            Vector3 end = start + lastCorrection;
            Gizmos.color = mtvColor;
            Gizmos.DrawLine(start, end);
            Gizmos.DrawSphere(end, 0.05f);
        }
    }
}