using UnityEngine;

namespace NavyTest.Character.Enemies
{
    [CreateAssetMenu(fileName = "new EnemyData", menuName = "EnemyData", order = 52)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _viewRadius;
        [SerializeField] private float _distanceToChangePoint;

        public float ViewRadius => _viewRadius;
        public float DistanceToChangePoint => _distanceToChangePoint;
        public float Speed => _speed;

        private void OnValidate()
        {
            if (_speed < 0)
                _speed = 0;
        }
    }
}
