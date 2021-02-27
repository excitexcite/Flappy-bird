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
    private bool gameOver = false; // bool variable that fobirds us to move when the bird is dead

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
            manager.EnableScore();
            manager.DisableStartUI();
        }

        if (Input.GetMouseButtonDown(0)) // if screen is touched bird flies up
        {
            rigidbody2D.velocity = Vector2.up * velocity;
        }

        // if the bird has to fall dawn (game over), this option helps us not to change bird direction when it is falling
        // bird will look down
        if (!gameOver) 
        {
            transform.eulerAngles = new Vector3(0, 0, rigidbody2D.velocity.y * 20f); // add some rotating while bird fly
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        manager.GameOver(); // if bird touch the ground or pipes gameover
    }
}
