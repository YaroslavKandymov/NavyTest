using System;
using NavyTest.Character;
using NavyTest.Other;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NavyTest.Gems
{
    public class Gem : Unit
    {
        [SerializeField] private GemsData _gemsData;

        public event Action<Gem> Collected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.FillMaxHealth();
                player.IncreaseScoresCount(Random.Range(_gemsData.MinScores, _gemsData.MaxScores));
            }

            Collected?.Invoke(this);

            gameObject.SetActive(false);
        }
    }
}
