using System.Collections.Generic;
using NavyTest.Character;
using NavyTest.Character.Enemies;
using NavyTest.Gems;
using UnityEngine;

namespace NavyTest.Other
{
    public class DistanceIndicator : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GemsSpawner _gemsSpawner;

        private readonly List<Gem> _gems = new List<Gem>();
        private readonly List<Enemy> _enemies = new List<Enemy>();

        private void OnEnable()
        {
            _enemySpawner.EnemyCreated += OnEnemyCreated;
            _gemsSpawner.GemCreated += OnGemCreated;
            _gemsSpawner.GemDestroyed += OnGemDestroyed;
        }

        private void OnDisable()
        {
            _enemySpawner.EnemyCreated -= OnEnemyCreated;
            _gemsSpawner.GemCreated -= OnGemCreated;
            _gemsSpawner.GemDestroyed -= OnGemDestroyed;
        }

        public float GetDistanceToClosestGem()
        {
            return GetClosestInCollection(_gems);
        }

        public float GetDistanceToClosestEnemy()
        {
            return GetClosestInCollection(_enemies);
        }

        private void OnGemDestroyed(Gem gem)
        {
            _gems.Remove(gem);
        }

        private void OnGemCreated(Gem gem)
        {
            _gems.Add(gem);
        }

        private void OnEnemyCreated(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        private float GetClosestInCollection(IEnumerable<Unit> collection)
        {
            float minDistance = float.MaxValue;

            foreach (var element in collection)
                if (GetDistance(element.transform, _player.transform) < minDistance)
                    minDistance = GetDistance(element.transform, _player.transform);

            return minDistance;
        }

        private float GetDistance(Transform firstTransform, Transform secondTransform)
        {
            return (firstTransform.position - secondTransform.position).sqrMagnitude;
        }
    }
}
