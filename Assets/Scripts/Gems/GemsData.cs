using UnityEngine;

namespace NavyTest.Gems
{
    [CreateAssetMenu(fileName = "new GemsData", menuName = "GemsData", order = 53)]
    public class GemsData : ScriptableObject
    {
        [SerializeField] private int _minScores;
        [SerializeField] private int _maxScores;

        public int MinScores => _minScores;
        public int MaxScores => _maxScores;

        private void OnValidate()
        {
            if (_minScores > _maxScores)
                _maxScores = _minScores;
        }
    }
}
