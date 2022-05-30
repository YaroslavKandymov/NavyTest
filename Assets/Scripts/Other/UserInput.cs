using System;
using UnityEngine;

namespace NavyTest.Other
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _maxDistance;

        private RaycastHit _hit;

        public event Action<Vector3> Clicked;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out _hit, _maxDistance))
                {
                    Clicked?.Invoke(_hit.point);
                }
            }
        }
    }
}
