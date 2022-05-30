using UnityEngine;
using UnityEngine.AI;

namespace NavyTest.Character
{
    public class CharacterMover
    {
        private NavMeshAgent _agent;

        public CharacterMover(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void MoveToPoint(Vector3 point)
        {
            _agent.SetDestination(point);
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }
    }
}
