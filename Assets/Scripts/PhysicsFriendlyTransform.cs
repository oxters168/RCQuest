using UnityEngine;

[ExecuteAlways]
public class PhysicsFriendlyTransform : MonoBehaviour
{
    public Rigidbody[] physicsChildren;

    [HideInInspector]
    private Vector3 _worldPosition;
    public Vector3 position { set { _worldPosition = value; } get { return _worldPosition; } }
    public Vector3 localPosition { set { _worldPosition = LocalToWorldPosition(value); } get { return transform.InverseTransformPoint(_worldPosition); } }

    [HideInInspector]
    private Quaternion _worldRotation = Quaternion.identity;
    public Quaternion rotation { set { _worldRotation = value; } get { return _worldRotation; } }
    public Quaternion localRotation { set { _worldRotation = LocalToWorldRotation(value); } get { return WorldToLocalRotation(_worldRotation); } }

    private void FixedUpdate()
    {
        float distance = (_worldPosition - transform.position).sqrMagnitude;
        float angle = Quaternion.Angle(_worldRotation, transform.rotation);

        if (!Mathf.Approximately(distance, 0) || !Mathf.Approximately(angle, 0))
        {
            Matrix4x4 trsMatrix = Matrix4x4.identity;
            trsMatrix.SetTRS(_worldPosition, _worldRotation, Vector3.one);
            Quaternion deltaRotate = _worldRotation * Quaternion.Inverse(transform.rotation);
            foreach (var physicsChild in physicsChildren)
            {
                physicsChild.transform.position = trsMatrix.MultiplyPoint(transform.InverseTransformPoint(physicsChild.position));
                physicsChild.transform.rotation = deltaRotate * physicsChild.transform.rotation;
                physicsChild.angularVelocity = deltaRotate * physicsChild.angularVelocity;
                physicsChild.velocity = deltaRotate * physicsChild.velocity;
            }
            transform.position = _worldPosition;
            transform.rotation = _worldRotation;
        }
    }

    public Quaternion LocalToWorldRotation(Quaternion rotation)
    {
        return Quaternion.Euler(transform.TransformDirection(rotation.eulerAngles));
    }
    public Quaternion WorldToLocalRotation(Quaternion rotation)
    {
        return Quaternion.Euler(transform.InverseTransformDirection(rotation.eulerAngles));
    }
    public Vector3 LocalToWorldPosition(Vector3 position)
    {
        return transform.TransformPoint(position);
    }
    public Vector3 WorldToLocalPosition(Vector3 position)
    {
        return transform.InverseTransformPoint(position);
    }
}
