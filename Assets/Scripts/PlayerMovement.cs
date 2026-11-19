using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controls how fast the player moves
    public float speed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    //New Health system add on 

    // Maxium amount of health the player can have
    public int maxHealth = 3;

    // Current health of player
    private int currentHealth;

    

void Start()
    {
        // Get the Rigidbody2D attached to the player
        rb = GetComponent<Rigidbody2D>();

        // New Health Add on
        currentHealth = maxHealth;

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

    // New Health system method
    public void ChangeHealth(int amount)
    {
        // Add or subtract health
        currentHealth = Mathf.Clamp(
            currentHealth + amount,
            0,
            maxHealth
        );

        // Print health to the Console/ temp for testing 
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
    }
}


