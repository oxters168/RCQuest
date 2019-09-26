using UnityEngine;

[ExecuteAlways]
public class PhysicsDebugGizmos : MonoBehaviour
{
    private Rigidbody body;
    public bool onSelected;
    public Color velocityColor = Color.blue;
    public Color angularVelocityColor = Color.yellow;

    private void OnEnable()
    {
        body = GetComponent<Rigidbody>();
        Debug.Assert(body != null, gameObject.name + ": Physics Debug Gizmos must be attached to a gameobject that has a Rigidbody component");
    }
    private void OnDrawGizmos()
    {
        if (!onSelected)
            DrawPhysicsGizmos();
    }
    private void OnDrawGizmosSelected()
    {
        if (onSelected)
            DrawPhysicsGizmos();
    }

    private void DrawPhysicsGizmos()
    {
        Gizmos.color = velocityColor;
        Gizmos.DrawRay(transform.position, body.velocity);

        Gizmos.color = angularVelocityColor;
        Gizmos.DrawRay(transform.position, body.angularVelocity);
    }
}
