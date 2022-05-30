using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NavyTest.UI.Panel
{
    public class GameOverPanel : Panel
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scores;

        public event Action RestartButtonClicked;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        public void SetScores(int scores)
        {
            _scores.text = scores.ToString();
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}
