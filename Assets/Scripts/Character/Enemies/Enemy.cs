using System.Collections;
using NavyTest.Extentions;
using NavyTest.Other;
using UnityEngine;
using UnityEngine.AI;

namespace NavyTest.Character.Enemies
{
    public class Enemy : Unit
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private NavMeshAgent _agent;

        private CharacterMover _characterMover;
        private Vector3 _randomPosition;

        private void Awake()
        {
            _characterMover = new CharacterMover(_agent);

            _agent.speed = _enemyData.Speed;
        }

        public void Move()
        {
            _randomPosition = transform.position.GetRandomPositionOnNavMesh(_enemyData.ViewRadius);
            StartCoroutine(MoveCoroutine());
        }

        public void Stop()
        {
            _characterMover.Stop();
        }

        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                _characterMover.MoveToPoint(_randomPosition);

                if ((_randomPosition - transform.position).sqrMagnitude <= _enemyData.DistanceToChangePoint)
                {
                    _randomPosition = transform.position.GetRandomPositionOnNavMesh(_enemyData.ViewRadius);
                }

                yield return null;
            }
        }
    }
}
