using System.Collections.Generic;
using UnityEngine;

namespace RollaBall
{
    public class RockSpawner : MonoBehaviour
    {
        public Transform[] spawns;
        public GameObject[] objects;
 
        void Start()
        { 
            SpawnObjects(objects, spawns);
        }
 
        private void SpawnObjects(GameObject[] gameObjects, Transform[] locations, bool allowOverlap = true)
        {
            List<GameObject> remainingGameObjects = new List<GameObject>(gameObjects);
            List<Transform> freeLocations = new List<Transform>(locations);
 
            if(locations.Length < gameObjects.Length)
                Debug.LogWarning( allowOverlap  ? "There are more gameObjects than locations. Some objects will overlap." : "There are not enough locations for all the gameObjects. Some won't spawn.");
 
            while(remainingGameObjects.Count > 0)
            {
                if(freeLocations.Count == 0 )
                {
                    if( allowOverlap ) 
                        freeLocations.AddRange(locations);
                    else               
                        break ;
                }
 
                int gameObjectIndex = Random.Range(0, remainingGameObjects.Count);
                int locationIndex = Random.Range(0, freeLocations.Count);
                for (int i = 0; i < spawns.Length; i++)
                {
                    Instantiate(gameObjects[gameObjectIndex], locations[locationIndex].position, Quaternion.identity);
                    remainingGameObjects.RemoveAt(gameObjectIndex);
                    freeLocations.RemoveAt(locationIndex);
                }
            }
        }
    }
}
