using UnityEngine;

namespace NavyTest.Other
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _offset;
        private Transform _transform;

        private void Start()
        {
            _offset = transform.position - _target.transform.position;
            _transform = GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            var targetPosition = new Vector3(_target.transform.position.x + _offset.x, transform.position.y, _target.transform.position.z + _offset.z);
            _transform.position = targetPosition;
        }
    }
}
