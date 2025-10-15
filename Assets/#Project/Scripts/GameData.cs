using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Design/GameData")]
public class GameData : ScriptableObject
{
    [field: SerializeField] public CameraData Camera { get; private set; }
    [field: SerializeField] public SpawningData Spawning { get; private set; }

} 
