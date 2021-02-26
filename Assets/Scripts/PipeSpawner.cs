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


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawnPipes)
        {
            yield return StartCoroutine(SpawnPipes());
        }
    }

    IEnumerator SpawnPipes()
    {
        GameObject newPipe = Instantiate(pipe);
        Vector3 randomFactor = new Vector3(0, Random.Range(-height, height), 0);
        newPipe.transform.position = transform.position + randomFactor;
        Destroy(newPipe, 5f);
        yield return new WaitForSeconds(timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
/*        if (timer > timeToSpawn)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newPipe, 15f);
        }
        timer += Time.deltaTime;*/
    }


}
