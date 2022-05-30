using System.Collections;
using System.Collections.Generic;
using NavyTest.Character;
using NavyTest.Character.Enemies;
using NavyTest.Gems;
using NavyTest.Other;
using TMPro;
using UnityEngine;

namespace NavyTest.UI.Panel
{
    public class GamePanel : Panel
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _scores;
        [SerializeField] private Heart _heart;
        [SerializeField] private Transform _heartsParent;
        [SerializeField] private TMP_Text _gemsCount;
        [SerializeField] private TMP_Text _enemiesCount;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GemsSpawner _gemsSpawner;
        [SerializeField] private DistanceIndicator _distanceIndicator;
        [SerializeField] private TMP_Text _distanceToGem;
        [SerializeField] private TMP_Text _distanceToEnemy;

        private readonly List<Heart> _hearts = new List<Heart>();

        private int _currentHeartNumber;
        private int _currentEnemyCount;
        private int _currentGemCount;

        private void OnEnable()
        {
            _player.ScoresCountChanged += OnScoresCountChanged;
            _player.HealthChanged += OnHealthChanged;
            _enemySpawner.EnemyCreated += OnEnemyCreated;
            _gemsSpawner.GemCreated += OnGemCreated;
            _gemsSpawner.GemDestroyed += OnGemDestroyed;
        }

        private void OnDisable()
        {
            _player.ScoresCountChanged -= OnScoresCountChanged;
            _player.HealthChanged -= OnHealthChanged;
            _enemySpawner.EnemyCreated -= OnEnemyCreated;
            _gemsSpawner.GemCreated -= OnGemCreated;
            _gemsSpawner.GemDestroyed -= OnGemDestroyed;
        }

        private void Start()
        {
            _scores.text = "0";

            CreateHearts();
        }

        private void Update()
        {
            _distanceToGem.text = Mathf.Round(_distanceIndicator.GetDistanceToClosestGem()).ToString();
            _distanceToEnemy.text = Mathf.Round(_distanceIndicator.GetDistanceToClosestEnemy()).ToString();
        }

        private void OnScoresCountChanged(int count)
        {
            _scores.text = count.ToString();
        }

        private void OnHealthChanged(int value)
        {
            if (value - 1 < _currentHeartNumber)
            {
                _hearts[_currentHeartNumber].Empty();
                _currentHeartNumber--;
            }
            else
            {
                FillHearts();
            }
        }

        private void FillHearts()
        {
            StartCoroutine(FillHeartsCoroutine());
        }

        private IEnumerator FillHeartsCoroutine()
        {
            while (_currentHeartNumber < _hearts.Count)
            {
                _hearts[_currentHeartNumber].Fill();

                yield return new WaitForSeconds(_hearts[_currentHeartNumber].Duration);

                if (_currentHeartNumber < _hearts.Count - 1)
                {
                    _currentHeartNumber++;
                }
                else
                {
                    yield break;
                }
            }
        }

        private void CreateHearts()
        {
            for (int i = 0; i < _player.MaxHealth; i++)
            {
                var heart = Instantiate(_heart, _heartsParent);
                _hearts.Add(heart);
            }

            _currentHeartNumber = _hearts.Count - 1;
        }

        private void OnEnemyCreated(Enemy enemy)
        {
            _currentEnemyCount++;
            _enemiesCount.text = _currentEnemyCount.ToString();
        }

        private void OnGemCreated(Gem gem)
        {
            _currentGemCount++;
            _gemsCount.text = _currentGemCount.ToString();
        }

        private void OnGemDestroyed(Gem gem)
        {
            _currentGemCount--;
            _gemsCount.text = _currentGemCount.ToString();
        }
    }
}
