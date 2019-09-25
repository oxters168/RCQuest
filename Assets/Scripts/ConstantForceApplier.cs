using UnityEngine;

public class ConstantForceApplier : MonoBehaviour
{
    public Vector3 forceDirection;
    public bool localDirection;
    public float gravityForce = 9.8f;
    private Vector3 worldDirection;

    private Rigidbody body;

    private void OnEnable()
    {
        body = GetComponent<Rigidbody>();
        Debug.Assert(body != null, gameObject.name + ": Constant Force Applier must be attached to a gameobject that has a Rigidbody component");
    }
    private void FixedUpdate()
    {
        if (body != null)
        {
            worldDirection = GetForceDirection(forceDirection, localDirection);
            body.AddForce(worldDirection * gravityForce, ForceMode.Acceleration);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, GetForceDirection(forceDirection, localDirection));
    }

    public Vector3 GetForceDirection(Vector3 direction, bool local)
    {
        Vector3 outputDirection;
        if (local && transform.parent != null)
            outputDirection = transform.parent.TransformDirection(direction);
        else
            outputDirection = direction;

        return outputDirection.normalized;
    }
}
