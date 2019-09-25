using UnityEngine;

public class ActorController : MonoBehaviour
{
    public NWH.VehiclePhysics.VehicleController activeVehicle;
    public PhysicsFriendlyTransform world;

    public float primaryTriggerValue, primaryGripValue, secondaryGripValue;
    public bool primaryJoystickButton;
    public Vector2 primaryJoystick;

    public float positionMoveScale = 100;
    private bool isMovingWorld;
    public Vector3 controllerPosition;
    private Vector3 previousPosition;
    public Quaternion controllerRotation = Quaternion.identity;
    private Quaternion previousRotation = Quaternion.identity;

    public virtual void Update()
    {
        ApplyInput();
    }

    public void ApplyInput()
    {
        activeVehicle.input.Vertical = primaryTriggerValue - primaryGripValue;
        activeVehicle.input.Horizontal = primaryJoystick.x;
        activeVehicle.input.Handbrake = primaryJoystickButton ? 1 : 0;

        if (secondaryGripValue > 0 && !isMovingWorld)
        {
            previousPosition = controllerPosition;
            previousRotation = controllerRotation;
            isMovingWorld = true;
        }
        else if (secondaryGripValue <= 0)
            isMovingWorld = false;

        if (isMovingWorld)
        {
            world.position += (controllerPosition - previousPosition) * positionMoveScale;
            Quaternion deltaRotation = controllerRotation * Quaternion.Inverse(previousRotation);
            world.rotation = deltaRotation * world.rotation;
            Debug.Log("Delta: " + deltaRotation + " Previous Rotation: " + previousRotation + " Current Rotation: " + controllerRotation + " World Rotation: " + world.rotation);

            previousPosition = controllerPosition;
            previousRotation = controllerRotation;
        }
    }
}
