using NavyTest.Character.Enemies;
using UnityEngine;

namespace NavyTest.Level
{
    [CreateAssetMenu(fileName = "new LevelData", menuName = "LevelData", order = 54)]
    public class LevelData : ScriptableObject
    {
        [Header("Grid")] [SerializeField] private float _cellSize;
        [SerializeField] private int _gridWidth;
        [SerializeField] private int _gridHeight;
        [Header("Obstacle")] [SerializeField] private int _obstaclesCount;
        [Header("Gems")] [SerializeField] private float _minTimeGemsSpawn;
        [SerializeField] private float _maxTimeGemsSpawn;
        [SerializeField] private int _gemsStartCount;
        [SerializeField] private int _gemsMaxCount;
        [Header("Enemy")] [SerializeField] private float _enemySpawnTime;
        [SerializeField] private int _enemyMaxCount;
        [SerializeField] private EnemyZoneSpawner[] _enemyZoneSpawners;

        public float CellSize => _cellSize;
        public int GridWidth => _gridWidth;
        public int GridHeight => _gridHeight;
        public int ObstaclesCount => _obstaclesCount;
        public float MinTimeGemsSpawn => _minTimeGemsSpawn;
        public float MaxTimeGemsSpawn => _maxTimeGemsSpawn;
        public int GemsStartCount => _gemsStartCount;
        public int GemsMaxCount => _gemsMaxCount;
        public float EnemySpawnTime => _enemySpawnTime;
        public int EnemyMaxCount => _enemyMaxCount;
        public EnemyZoneSpawner[] EnemyZoneSpawners => _enemyZoneSpawners;

        private void OnValidate()
        {
            if (_minTimeGemsSpawn > _maxTimeGemsSpawn)
                _maxTimeGemsSpawn = _minTimeGemsSpawn;

            if (_gemsStartCount > _gemsMaxCount)
                _gemsMaxCount = _gemsStartCount;
        }
    }
}
