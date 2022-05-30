using UnityEngine;

namespace NavyTest.Character.Enemies
{
    [System.Serializable]
    public class EnemyZoneSpawner
    {
        [SerializeField] private Vector3Int _enemyZoneCenter;
        [SerializeField] private int _enemySpawnZoneWidth;
        [SerializeField] private int _enemySpawnZoneHeight;

        public Vector3Int EnemyZoneCenter => _enemyZoneCenter;
        public int EnemySpawnZoneWidth => _enemySpawnZoneWidth;
        public int EnemySpawnZoneHeight => _enemySpawnZoneHeight;
    }
}