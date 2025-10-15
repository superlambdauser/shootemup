using UnityEngine;

[CreateAssetMenu(fileName = "CameraData", menuName = "Scriptable Objects/CameraData")]
public class CameraData : ScriptableObject
{
    [field: SerializeField] public Vector3 Position { get; private set; }
    [field: SerializeField] public Quaternion Rotation { get; private set; }
}
