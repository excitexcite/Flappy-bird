using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to allow pipes to spawn. Places on pipeSpawner object
 */
public class PipeSpawner : MonoBehaviour
{

    [SerializeField] private float timeToSpawn = 1f; // time to the next pipes spawn
    [SerializeField] GameObject pipe; // pipe object prefab
    [SerializeField] private float height; // value that randomly influence pipe Y position
    [SerializeField] private bool spawnPipes = true; // bool variable that tells wheather we have to spawn pipes;
    private Coroutine spawningCoroutine; // coroutine that is able to stop spawning pipes

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator SpawnPipes()
    {
        while (spawnPipes)
        {
            GameObject newPipe = Instantiate(pipe); // istantiating pipe
            Vector3 randomFactor = new Vector3(0, Random.Range(-height, height), 0); // getting tha value to shift pipe up or down
            newPipe.transform.position = transform.position + randomFactor; // shifting pipe
            Destroy(newPipe, 5f); // destroying pipe in 5 seconds
            yield return new WaitForSeconds(timeToSpawn); // waiting till the next spawn
        }
    }

    public void StartSpawning()
    {
        spawningCoroutine = StartCoroutine(SpawnPipes()); // start spawingn pipes
    }

    public void StopSpawning()
    {
        StopCoroutine(spawningCoroutine); // stop spawning pipes
    }

    // Update is called once per frame
    void Update()
    {

    }
}
