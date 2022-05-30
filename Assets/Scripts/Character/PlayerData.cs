using UnityEngine;

namespace NavyTest.Character
{
    [CreateAssetMenu(fileName = "new PlayerData", menuName = "PlayerData", order = 51)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _health;
        [SerializeField] private float _immortalTime;

        public float Speed => _speed;
        public int Health => _health;
        public float ImmortalTime => _immortalTime;
    }
}
