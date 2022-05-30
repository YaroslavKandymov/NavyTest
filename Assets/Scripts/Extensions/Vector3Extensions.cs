using UnityEngine;
using UnityEngine.AI;

namespace NavyTest.Extentions
{
    public static class Vector3Extensions
    {
        public static Vector3 GetRandomPositionOnNavMesh(this Vector3 center, float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;

            randomDirection += center;

            Vector3 finalPosition = Vector3.zero;

            if (NavMesh.SamplePosition(randomDirection, out var hit, radius, 1))
            {
                finalPosition = hit.position;
            }

            return finalPosition;
        }
    }
}
