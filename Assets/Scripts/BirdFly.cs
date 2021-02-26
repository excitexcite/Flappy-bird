using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{

    [SerializeField] float velocity = 1;
    private Rigidbody2D rigidbody2D;
    private bool alreadyTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !alreadyTouched)
        {
            Debug.Log("Touched once");
            alreadyTouched = true;
            rigidbody2D.isKinematic = false;
            FindObjectOfType<PipeSpawner>().StartSpawning();
        }

        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector2.up * velocity;
        }
    }
}
