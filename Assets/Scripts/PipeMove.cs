using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script to allow pipes to move. Places on pipes prefab.
 */
public class PipeMove : MonoBehaviour
{

    [SerializeField] private float speed = 1f; // pipes move speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // move pipes to the left of the screen
    }
}
