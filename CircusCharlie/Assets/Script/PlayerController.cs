using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 400f;
    public float moveSpeed = 10f;
    public int jumpCount = 0;

    private bool isGrounded = true;
    private bool isDead = false;

    private Animator animator = default;
    Rigidbody2D playerRigid = default;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameClear == true) { return; }

        if (isDead == true) { return; }
        if(Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        animator.SetBool("Ground", isGrounded);

    


    }
    private void Die()
    {
        animator.SetTrigger("Die");
        /*playerAudio.clip = deathClip;
        playerAudio.Play();*/

        playerRigid.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnplayerDead();



    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
       // Debug.Log(collision.tag);
        if (collision.tag.Equals("Dead"))
        {
            Die();
        }
        if(collision.tag.Equals("addScore"))
        {
            GameManager.instance.AddScore(100);
        }
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag.Equals("Floor"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        if (collision.collider.tag.Equals("Win"))
        {
            isGrounded = true;
            animator.SetBool("Ground", isGrounded);
            GameManager.instance.GameClear();
            
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
            isGrounded = false;
            
      
    }
}

