using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace NavyTest.UI
{
    [RequireComponent(typeof(Image))]
    public class Heart : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        private Image _image;

        public event Action Filled;
        public event Action Emptied;

        public float Duration => _duration;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.fillAmount = 1;
        }

        public void Fill()
        {
            _image.DOFillAmount(1, _duration).SetEase(_ease).OnComplete(() => Filled?.Invoke());
        }

        public void Empty()
        {
            _image.DOFillAmount(0, _duration).SetEase(_ease).OnComplete(() => Emptied?.Invoke());
        }
    }
}
