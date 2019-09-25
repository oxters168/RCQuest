using UnityEngine;

[ExecuteAlways]
public class PhysicsFriendlyTransform : MonoBehaviour
{
    [HideInInspector]
    private Vector3 _worldPosition;
    public Vector3 position { set { _worldPosition = value; } get { return _worldPosition; } }
    public Vector3 localPosition { set { _worldPosition = LocalToWorldPosition(value); } get { return transform.InverseTransformPoint(_worldPosition); } }

    [HideInInspector]
    private Quaternion _worldRotation = Quaternion.identity;
    public Quaternion rotation
    {
        set
        {
            _worldRotation = value;
        }
        get
        {
            return _worldRotation;
        }
    }
    public Quaternion localRotation { set { _worldRotation = LocalToWorldRotation(value); } get { return WorldToLocalRotation(_worldRotation); } }

    private void FixedUpdate()
    {
        transform.position = _worldPosition;
        transform.rotation = _worldRotation;
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
