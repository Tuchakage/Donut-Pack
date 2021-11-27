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
            AddTransformObstacles();
        }

        public void SpawnObstaclesRandom()
        {
            obstacleIndex = Random.Range(0, _obstacles.Count);
            transformIndex = Random.Range(0, spawnPoints.Count);
            
            GameObject obstacleClone = Instantiate(_obstacles[obstacleIndex], spawnPoints[transformIndex].position, Quaternion.identity);
            obstacleClone.transform.parent = transform;
        }

        public void AddTransformObstacles()
        {
            //For each item in the Material list
            for (int i = 0; i < spawnPoints.Count; i++) 
            {
                //Add them into the Dictionary for sprinkle colours
                spawnPoints.Add(spawnPoints[i]);

                Debug.Log(spawnPoints[i]);
            }
            
            for (int i = 0; i < _obstacles.Count; i++) 
            {
                //Add them into the Dictionary for sprinkle colours
                _obstacles.Add(_obstacles[i]);

                Debug.Log(_obstacles[i]);
            }
        }
    }
}
