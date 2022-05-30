using NavyTest.Extentions;
using UnityEngine;

namespace NavyTest.UI.Panel
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Panel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Close();
        }

        public void Open()
        {
            _canvasGroup.Open();
        }

        public void Close()
        {
            _canvasGroup.Close();
        }
    }
}
