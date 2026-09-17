using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float JumpMultiplier = 1f;

    private float speedMultiplier = 1f;
    [SerializeField] private float jump;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private bool grounded;

    private void Awake()
    {   
        // Grabs references for Rigidbody and Animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        SpeedItem.OnSpeedCollected += StartSpeedBoost; 
        JumpItem.OnSpeedCollected += StartJumpBoost;
    }

    private void OnDestroy()
    {
        SpeedItem.OnSpeedCollected -= StartSpeedBoost; 
        JumpItem.OnSpeedCollected -= StartJumpBoost; // im too good 

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed * speedMultiplier, body.velocity.y);

        // Flip player when facing left/right.
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1.5f, transform.localScale.y, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1.5f, transform.localScale.y, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            Debug.Log("Jump");
        }   

        // Sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    private void Jump()
    {
      body.velocity = new Vector2(body.velocity.x, jump * JumpMultiplier); // added the '* jumpMultiplier' as jump boost wasn't coming into effect before hand
      anim.SetTrigger("jump");  // Fixed the typo here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground") 
        {
            anim.SetBool("jump", false);
            grounded = true;
        }
    }

    void StartSpeedBoost(float multiplier)
    {
        StartCoroutine(SpeedBoosCoroutine(multiplier)); 
    }

        void StartJumpBoost(float multiplier)
    {
        StartCoroutine(JumpboostCoroutine(multiplier)); 
    }


    private IEnumerator SpeedBoosCoroutine(float multiplier)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(3f);
        speedMultiplier = 1f;
    }
    private IEnumerator JumpboostCoroutine(float multiplier)
    {
        JumpMultiplier = multiplier;
        yield return new WaitForSeconds(5f);
        JumpMultiplier = 1f;
    }
}
