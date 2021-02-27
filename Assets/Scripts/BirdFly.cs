using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{

    [SerializeField] float velocity = 1; // bird fly up speed
    [SerializeField] Level level; // level object reference
    [SerializeField] Manager manager; // manage object reference
    private Rigidbody2D rigidbody2D; // reference to control bird's rigit body component (velocity)
    private bool alreadyTouched = false; // bool variable that tells if the screen was touched

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // getting bird's rigit body component on game start
        rigidbody2D.isKinematic = true; // disabling rigidbody gravity property
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !alreadyTouched) // if it's the screen touch
        {
            Debug.Log("Touched once"); 
            alreadyTouched = true; // pointing that first touch was made
            rigidbody2D.isKinematic = false; // enabling rigidbody gravity property
            FindObjectOfType<PipeSpawner>().StartSpawning(); // telling the spawner to star spawning pipes
        }

        if (Input.GetMouseButtonDown(0)) // if screen is touched bird flies up
        {
            rigidbody2D.velocity = Vector2.up * velocity;
        }
        transform.eulerAngles = new Vector3(0, 0, rigidbody2D.velocity.y * 20f); // add some rotating while bird fly
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.GameOver(); // if bird touch the ground or pipes gameover
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
