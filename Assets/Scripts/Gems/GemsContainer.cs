using NavyTest.Other;
using UnityEngine;

namespace NavyTest.Gems
{
    public class GemsContainer : ObjectPool<Gem>
    {
        [SerializeField] private Gem _gemTemplate;

        private void Awake()
        {
            Initialize(_gemTemplate);
        }

        public Gem GetGem()
        {
            if (TryGetObject(out Gem gem))
            {
                gem.gameObject.SetActive(true);

                return gem;
            }
            else
            {
                return null;
            }
        }
    }
}
