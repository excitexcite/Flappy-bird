using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] private float timeToSpawn = 1f;
    private float timer = 0;
    [SerializeField] GameObject pipe;
    [SerializeField] private float height;
    [SerializeField] private bool spawnPipes = true;
    private Coroutine spawningCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator SpawnPipes()
    {
        while (spawnPipes)
        {
            GameObject newPipe = Instantiate(pipe);
            Vector3 randomFactor = new Vector3(0, Random.Range(-height, height), 0);
            newPipe.transform.position = transform.position + randomFactor;
            Destroy(newPipe, 5f);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    public void StartSpawning()
    {
        spawningCoroutine = StartCoroutine(SpawnPipes());
    }

    public void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
