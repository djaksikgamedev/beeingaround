using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabToSpawn;
    public Transform[] spawnPoints;

    public float minDelay;
    public float maxDelay;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            int prefabIndex = Random.Range(0, prefabToSpawn.Length);

            Instantiate(prefabToSpawn[prefabIndex], spawnPoint.position, spawnPoint.rotation);
        }
    }
}