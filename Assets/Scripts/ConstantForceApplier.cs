using UnityEngine;

public class ConstantForceApplier : MonoBehaviour
{
    public Vector3 forceDirection;
    //public bool localDirection;
    public Transform localTo;
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
            worldDirection = GetForceDirection(forceDirection, localTo);
            body.AddForce(worldDirection * gravityForce, ForceMode.Acceleration);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, GetForceDirection(forceDirection, localTo));
    }

    public Vector3 GetForceDirection(Vector3 direction, Transform directionParent)
    {
        Vector3 outputDirection;
        if (localTo != null)
            outputDirection = localTo.TransformDirection(direction);
        else
            outputDirection = direction;

        return outputDirection.normalized;
    }
}
