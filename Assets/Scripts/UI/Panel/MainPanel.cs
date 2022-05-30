using System;
using NavyTest.Character;
using UnityEngine;

namespace NavyTest.UI.Panel
{
    public class MainPanel : MonoBehaviour
    {
        private const string MaxScores = "MaxScores";

        [SerializeField] private Player _player;
        [SerializeField] private StartPanel _startPanel;
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private GameOverPanel _gameOverPanel;

        public event Action StartButtonClicked;
        public event Action RestartButtonClicked;
        public event Action GameOver;

        private void OnEnable()
        {
            _player.Died += OnDied;
            _startPanel.StartButtonClicked += OnStartButtonClicked;
            _gameOverPanel.RestartButtonClicked += OnRestartButtonClicked;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _startPanel.StartButtonClicked -= OnStartButtonClicked;
            _gameOverPanel.RestartButtonClicked -= OnRestartButtonClicked;
        }

        private void Start()
        {
            _startPanel.Open();
        }

        private void OnDied()
        {
            GameOver?.Invoke();

            _gamePanel.Close();
            _gameOverPanel.Open();

            if (_player.Scores > PlayerPrefs.GetInt(MaxScores))
            {
                PlayerPrefs.SetInt(MaxScores, _player.Scores);
                PlayerPrefs.Save();
            }

            _gameOverPanel.SetScores(PlayerPrefs.GetInt(MaxScores));
        }

        private void OnStartButtonClicked()
        {
            _startPanel.Close();
            _gamePanel.Open();
            StartButtonClicked?.Invoke();
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}
