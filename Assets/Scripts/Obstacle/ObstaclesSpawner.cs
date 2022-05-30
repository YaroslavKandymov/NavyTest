using NavyTest.Other;
using UnityEngine;
using UnityEngine.AI;

namespace NavyTest.Obstacle
{
    public class ObstaclesSpawner : Spawner
    {
        [SerializeField] private Obstacle _template;
        [SerializeField] private NavMeshSurface _navMeshSurface;

        public override void Spawn()
        {
            for (int i = 0; i < LevelData.ObstaclesCount; i++)
            {
                var obstacle = Instantiate(_template, transform);

                LevelGenerator.TryPutOnGrid(LevelGenerator.GetRandomPositionOnGrid(LevelData.GridWidth, LevelData.GridHeight), obstacle);
            }

            BakeMesh();
        }

        private void BakeMesh()
        {
            _navMeshSurface.BuildNavMesh();
        }
    }
}
