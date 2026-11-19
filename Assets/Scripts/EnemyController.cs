using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Public Variables 

    // Controls how fast the Shadow Creature moves 
    public float speed = 2f;

    // Distance the Shadow Creature notices the player
    public float detectionRange = 5f;

    // Reference to the player's transform
    private Transform player;

    // Private variables
    Rigidbody2D rigidbody2d;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // Find the player using the player tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // If a player exists, store its Transform
        if 
            (playerObject != null )
        {
            player = playerObject.transform;
        }
    }




    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        // Stop if player reference cannot be found
        if (player == null)
        {
            return;
        }

        // Get the PlayerMovement script
        PlayerMovement playerScript =
            player.GetComponent<PlayerMovement>();

        // If the player is inside a SafeZone stop
        
        if (playerScript != null && playerScript.isSafe)
        {
            return;
        }

        // Calculate distance between enemy and player
        float distance =
            Vector2.Distance(transform.position, player.position);

        // Only chase when player is inside detection range
        if (distance < detectionRange)
        {
            // Create a direction vector toward the player
            Vector2 direction =
                ((Vector2)player.position - rigidbody2d.position).normalized;

            // Move the Shadow Creature toward the player
            rigidbody2d.MovePosition(
                rigidbody2d.position +
                direction * speed * Time.fixedDeltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object touching the enemy
        // has the PlayerMovement script attached
        PlayerMovement playerScript =
            other.GetComponent<PlayerMovement>();

        // Damage the player if found
        if (playerScript != null && !playerScript.isSafe)
        {
            playerScript.ChangeHealth(-1);
        }



    }

}
