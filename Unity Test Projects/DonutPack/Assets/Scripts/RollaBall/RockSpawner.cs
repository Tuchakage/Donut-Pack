using System.Collections.Generic;
using UnityEngine;

namespace RollaBall
{
    public class RockSpawner : MonoBehaviour
    {
        public List<Transform> spawnPoints = new List<Transform>();
        public List<GameObject> _obstacles = new List<GameObject>();

        private int obstacleIndex;
        private int transformIndex;

        private void Start()
        {
            SpawnObstaclesRandom();
        }

        public void SpawnObstaclesRandom()
        {
            obstacleIndex = Random.Range(0, _obstacles.Count);
            transformIndex = Random.Range(0, spawnPoints.Count);
            
            GameObject obstacleClone = Instantiate(_obstacles[obstacleIndex], spawnPoints[transformIndex].position, Quaternion.identity);
            obstacleClone.transform.parent = transform;
        }
        
    }
}
