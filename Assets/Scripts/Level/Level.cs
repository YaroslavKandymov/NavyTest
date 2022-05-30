using NavyTest.Character;
using NavyTest.Other;
using NavyTest.UI.Panel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NavyTest.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private UserInput _userInput;
        [SerializeField] private MainPanel _mainPanel;
        [SerializeField] private Spawner[] _spawners;

        private void Awake()
        {
            _userInput.enabled = false;
        }

        private void OnEnable()
        {
            _mainPanel.StartButtonClicked += OnStartButtonClicked;
            _mainPanel.RestartButtonClicked += OnRestartButtonClicked;
            _mainPanel.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _mainPanel.StartButtonClicked -= OnStartButtonClicked;
            _mainPanel.RestartButtonClicked -= OnRestartButtonClicked;
            _mainPanel.GameOver -= OnGameOver;
        }

        private void OnGameOver()
        {
            _userInput.enabled = false;

            foreach (var spawner in _spawners)
            {
                spawner.Stop();
            }
        }

        private void OnRestartButtonClicked()
        {
            Restart();
        }

        private void OnStartButtonClicked()
        {
            _userInput.enabled = true;

            foreach (var spawner in _spawners)
            {
                spawner.Spawn();
            }
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
