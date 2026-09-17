using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaserMovement : MonoBehaviour
{
    public Transform player;  
    public float speed = 5f;  
    public float acceleration = 0.1f;  
    public float catchDistance = 1f;  

    private bool isChasing = true;  
    private Animator animator;  // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        if (isChasing)
        {
            animator.SetBool("isChasing", true); // Trigger the chasing animation
            ChasePlayer();

            if (Vector3.Distance(transform.position, player.position) < catchDistance)
            {
                isChasing = false;  // Stops when player is caught
                animator.SetBool("isChasing", false); // Switch to idle animation
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the chaser towards the player, with gradual speed increase
        transform.position += direction * speed * Time.deltaTime;

        // Gradually increase the chaser's speed for more difficulty over time
        speed += acceleration * Time.deltaTime;

        animator.SetFloat("speed", speed);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
    if (other.gameObject.CompareTag("Player"))
     {
    
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save(); 

        SceneManager.LoadScene("batlle");
    }
    }

}