using System;
using System.Collections;
using System.Collections.Generic;
using NavyTest.Other;
using UnityEngine;

namespace NavyTest.Character.Enemies
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy _enemyTemplate;

        private readonly List<Enemy> _enemies = new List<Enemy>();

        private int _currentEnemyCount;
        private WaitForSeconds _enemySpawnSeconds;
        private Coroutine _coroutine;

        public event Action<Enemy> EnemyCreated;

        private void Start()
        {
            _enemySpawnSeconds = new WaitForSeconds(LevelData.EnemySpawnTime);
        }

        public override void Spawn()
        {
            _coroutine = StartCoroutine(CreateCoroutine());
        }

        public override void Stop()
        {
            StopCoroutine(_coroutine);

            foreach (var enemy in _enemies)
            {
                enemy.Stop();
            }
        }

        private IEnumerator CreateCoroutine()
        {
            while (true)
            {
                if (_currentEnemyCount < LevelData.EnemyMaxCount)
                {
                    var enemy = Instantiate(_enemyTemplate, transform);
                    _enemies.Add(enemy);

                    _currentEnemyCount++;

                    EnemyCreated?.Invoke(enemy);

                    LevelGenerator.TryPutOnGrid(LevelGenerator.GetRandomPositionInEnemyZone(), enemy);

                    enemy.Move();
                }
                else
                {
                    yield break;
                }

                yield return _enemySpawnSeconds;
            }
        }
    }
}
