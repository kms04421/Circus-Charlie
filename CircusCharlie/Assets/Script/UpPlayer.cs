using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlayer : MonoBehaviour
{
    private Animator animator = default;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer1;
    // Start is called before the first frame update
    void Start()
    {
    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            FlipSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {


            UnFlipSprite();
        }
    }
    private void Die()
    {
        animator.SetTrigger("Die");
        /*playerAudio.clip = deathClip;
        playerAudio.Play();*/

    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag.Equals("Dead"))
        {
            Die();
        }
    }
    private void FlipSprite()
    {
        spriteRenderer.flipX = true; // ÁÂ¿ì ¹ÝÀü
        spriteRenderer1.flipX = true; // ÁÂ¿ì ¹ÝÀü
    }
    private void UnFlipSprite()
    {
        spriteRenderer.flipX = false; // ÁÂ¿ì ¹ÝÀü
        spriteRenderer1.flipX = false; // ÁÂ¿ì ¹ÝÀü
    }

}
