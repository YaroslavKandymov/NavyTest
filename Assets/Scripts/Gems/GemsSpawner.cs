using System;
using System.Collections;
using NavyTest.Other;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NavyTest.Gems
{
    public class GemsSpawner : Spawner
    {
        [SerializeField] private GemsContainer _gemsContainer;

        private int _currentGemsCount;
        private Coroutine _coroutine;

        public event Action<Gem> GemCreated;
        public event Action<Gem> GemDestroyed;

        public override void Spawn()
        {
            for (int i = 0; i < LevelData.GemsStartCount; i++)
            {
                Create();
            }

            _coroutine = StartCoroutine(CreateGemsCoroutine());
        }

        public override void Stop()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator CreateGemsCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(LevelData.MinTimeGemsSpawn, LevelData.MaxTimeGemsSpawn));

                if (_currentGemsCount < LevelData.GemsMaxCount)
                {
                    Create();
                }
            }
        }

        private void Create()
        {
            var gem = _gemsContainer.GetGem();

            if (gem == null)
                throw new NullReferenceException();

            gem.Collected += OnGemCollected;

            _currentGemsCount++;

            GemCreated?.Invoke(gem);

            LevelGenerator.TryPutOnGrid(
                LevelGenerator.GetRandomPositionOnGrid(LevelData.GridWidth, LevelData.GridHeight), gem);
        }

        private void OnGemCollected(Gem gem)
        {
            LevelGenerator.RemoveFromGrid(gem.transform.position);
            _currentGemsCount--;

            GemDestroyed?.Invoke(gem);

            gem.Collected -= OnGemCollected;
        }
    }
}
