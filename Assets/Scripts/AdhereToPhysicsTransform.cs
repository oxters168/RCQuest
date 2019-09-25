using UnityEngine;

public class AdhereToPhysicsTransform : MonoBehaviour
{
    public PhysicsFriendlyTransform transformToAdhereTo;
    private Rigidbody body;

    private Quaternion previousRotation;

    private void OnEnable()
    {
        body = GetComponent<Rigidbody>();
        Debug.Assert(body != null, gameObject.name + ": Constant Force Applier must be attached to a gameobject that has a Rigidbody component");
        previousRotation = transformToAdhereTo.rotation;
    }
    private void Update()
    {
        Quaternion deltaRotate = previousRotation * Quaternion.Inverse(transformToAdhereTo.rotation);
        body.angularVelocity = deltaRotate * body.angularVelocity;
        body.velocity = deltaRotate * body.velocity;
        previousRotation = transformToAdhereTo.rotation;
    }
}
