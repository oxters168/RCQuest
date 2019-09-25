using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PhysicsFriendlyTransform)), CanEditMultipleObjects]
public class PhysicsFriendlyTransformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //PhysicsFriendlyTransform[] myTargets = System.Array.ConvertAll(targets, item => (PhysicsFriendlyTransform)item);
        PhysicsFriendlyTransform myTarget = (PhysicsFriendlyTransform)target;

        //myTarget._worldPosition = myTarget.LocalToWorldPosition(EditorGUILayout.Vector3Field("Position", myTarget.WorldToLocalPosition(myTarget._worldPosition)));
        //myTarget._worldRotation = myTarget.LocalToWorldRotation(Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation", myTarget.WorldToLocalRotation(myTarget._worldRotation).eulerAngles)));

        //for (int i = 0; i < myTargets.Length; i++)
        //{
        //    myTargets[i]._worldPosition = myTargets[i].LocalToWorldPosition(EditorGUILayout.Vector3Field("Position", myTargets[i].WorldToLocalPosition(myTargets[i]._worldPosition)));
        //    myTargets[i]._worldRotation = myTargets[i].LocalToWorldRotation(Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation", myTargets[i].WorldToLocalRotation(myTargets[i]._worldRotation).eulerAngles)));
        //}
    }
}
