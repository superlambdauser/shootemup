using UnityEngine;

[CreateAssetMenu(fileName = "SpawningData", menuName = "Scriptable Objects/SpawningData")]
public class SpawningData : ScriptableObject
{
    [field: SerializeField] public int Batch { get; private set; }   
    [field: SerializeField] public float Cooldown { get; private set; }
}
