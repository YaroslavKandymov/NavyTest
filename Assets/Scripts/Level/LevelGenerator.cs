using System.Collections.Generic;
using NavyTest.Character.Enemies;
using NavyTest.Other;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NavyTest.Level
{
    public class LevelGenerator
    {
        private readonly LevelData _levelData;

        private readonly HashSet<Vector3Int> _collisionsMatrix;

        public LevelGenerator(LevelData levelData)
        {
            _levelData = levelData;
            _collisionsMatrix = new HashSet<Vector3Int>();
        }

        public Vector3Int GetRandomPositionOnGrid(int gridWidth, int gridHeight)
        {
            var randomPosition = new Vector3Int(Random.Range(-gridWidth / 2 + 1, gridWidth / 2), 0,
                Random.Range(-gridHeight / 2 + 1, gridHeight / 2));

            return randomPosition;
        }

        public Vector3Int GetRandomPositionInEnemyZone()
        {
            var randomZoneIndex = Random.Range(0, _levelData.EnemyZoneSpawners.Length - 1);
            var zone = _levelData.EnemyZoneSpawners[randomZoneIndex];

            var randomPosition = GetRandomPositionOnGrid(zone.EnemySpawnZoneWidth, zone.EnemySpawnZoneHeight) +
                                 zone.EnemyZoneCenter;

            return randomPosition;
        }

        public void TryPutOnGrid(Vector3Int gridPosition, Unit template)
        {
            if (_collisionsMatrix.Contains(gridPosition))
            {
                if (template is Enemy)
                {
                    TryPutOnGrid(GetRandomPositionInEnemyZone(), template);
                }
                else
                {
                    TryPutOnGrid(GetRandomPositionOnGrid(_levelData.GridWidth, _levelData.GridHeight), template);
                }
            }
            else
            {
                _collisionsMatrix.Add(gridPosition);
            }

            if (template == null)
                return;

            var position = GridToWorldPosition(gridPosition);

            template.transform.position = new Vector3(position.x, template.transform.position.y, position.z);
            ;
        }

        public void RemoveFromGrid(Vector3 position)
        {
            _collisionsMatrix.Remove(WorldToGridPosition(position));
        }

        private Vector3 GridToWorldPosition(Vector3Int gridPosition)
        {
            return new Vector3(
                gridPosition.x * _levelData.CellSize,
                gridPosition.y * _levelData.CellSize,
                gridPosition.z * _levelData.CellSize);
        }

        private Vector3Int WorldToGridPosition(Vector3 worldPosition)
        {
            return new Vector3Int(
                (int)(worldPosition.x / _levelData.CellSize),
                (int)(worldPosition.y / _levelData.CellSize),
                (int)(worldPosition.z / _levelData.CellSize));
        }
    }
}
