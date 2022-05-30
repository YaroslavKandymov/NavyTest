using NavyTest.Level;
using UnityEngine;

namespace NavyTest.Other
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;

        protected LevelGenerator LevelGenerator { get; private set; }
        protected LevelData LevelData => _levelData;

        private void Awake()
        {
            LevelGenerator = new LevelGenerator(_levelData);
        }

        public abstract void Spawn();

        public virtual void Stop()
        {
        }
    }
}
