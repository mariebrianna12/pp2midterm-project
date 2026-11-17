using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controls how fast the player moves
    public float speed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    void Start()
    {
        // Get the Rigidbody2D attached to the player
        rb = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {
        // Read Player input
        // A/D or Left/Right Arrow = Horizontal movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // W/S or Up/Down Arrow = Vertical movement
        movement.y = Input.GetAxisRaw("Vertical");


        // Normalize prevents diagonal movement from being faster
        movement = movement.normalized;
    }


    void FixedUpdate()
    {
        // Move the player using physics
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}


