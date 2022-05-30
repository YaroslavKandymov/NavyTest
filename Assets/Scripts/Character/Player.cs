using System;
using System.Collections;
using NavyTest.Character.Enemies;
using NavyTest.Other;
using UnityEngine;
using UnityEngine.AI;

namespace NavyTest.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private UserInput _userInput;
        [SerializeField] private Vector3 _startPosition;

        private CharacterMover _characterMover;
        private CharacterAnimationsPlayer _characterAnimationsPlayer;

        private int _currentHealth;
        private int _maxHealth;
        private int _scores;
        private WaitForSeconds _immortalTime;
        private bool _isImmortal;

        public event Action Died;
        public event Action<int> ScoresCountChanged;
        public event Action<int> HealthChanged;

        public int MaxHealth => _maxHealth;
        public int Scores => _scores;

        private void Awake()
        {
            _currentHealth = _playerData.Health;
            _maxHealth = _playerData.Health;
            _agent.speed = _playerData.Speed;

            _characterMover = new CharacterMover(_agent);
            _characterAnimationsPlayer = new CharacterAnimationsPlayer(_animator);
            _immortalTime = new WaitForSeconds(_playerData.ImmortalTime);

            TakeStartPosition();
        }

        private void OnEnable()
        {
            _userInput.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _userInput.Clicked -= OnClicked;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                TakeDamage();
            }
        }

        public void FillMaxHealth()
        {
            _currentHealth = _maxHealth;

            HealthChanged?.Invoke(_currentHealth);
        }

        public void IncreaseScoresCount(int scores)
        {
            _scores += scores;

            ScoresCountChanged?.Invoke(_scores);
        }

        private void OnClicked(Vector3 point)
        {
            _characterMover.MoveToPoint(point);
            _characterAnimationsPlayer.PlayRunAnimation();
        }

        private void TakeDamage()
        {
            if (_isImmortal)
                return;

            _currentHealth -= 1;

            if (_currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(MakeImmortalCoroutine());
            }

            HealthChanged?.Invoke(_currentHealth);
        }

        private void Die()
        {
            Died?.Invoke();
        }

        private IEnumerator MakeImmortalCoroutine()
        {
            _isImmortal = true;

            yield return _immortalTime;

            _isImmortal = false;
        }

        private void TakeStartPosition()
        {
            transform.position = _startPosition;
        }
    }
}
