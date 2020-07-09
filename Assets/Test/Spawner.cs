using UnityEngine;
using System.Collections;

namespace Test
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject plane;
        [SerializeField] private float timeToSpawn = 3f;
        [SerializeField] private bool isRight = true;

        private readonly bool spawn = true;
        
        private void Start()
        {
            StartCoroutine(SpawnStart());
        }

        private IEnumerator SpawnStart()
        {
            var currentFlyer = plane.GetComponent<Flyer>();
            while (spawn)
            {
                currentFlyer.IsRightPosition = isRight;
                Instantiate(currentFlyer, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(timeToSpawn);
            }
        }
    }
}