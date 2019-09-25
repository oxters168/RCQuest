using UnityEngine;

public class TestPhysicsBehaviour : MonoBehaviour
{
    public PhysicsFriendlyTransform[] testSubjects;
    public Vector3 rotationDirection;
    public float rotationSpeed;

    private void Update()
    {
        foreach (var testSubject in testSubjects)
        {
            testSubject.rotation *= Quaternion.Euler(rotationDirection.normalized * rotationSpeed);
        }
    }
}
