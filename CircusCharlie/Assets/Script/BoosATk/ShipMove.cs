using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    private Animator animator;
    float shipHp ;
    float subTime;
    public SpriteRenderer spriteRenderer;
    bool RLType = false;
    // Start is called before the first frame update
    void Start()
    {
        subTime = 0;
        animator = GetComponent<Animator>();
        shipHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (shipHp > 0)
        {
            if (!RLType) 
            {
                transform.Translate(Vector3.left * 1 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * 1 * Time.deltaTime);
            }

        
        }
        else
        {
            animator.SetTrigger("Die");
          
            if (subTime > 0.40)
            {
             
                gameObject.SetActive(false);
            }
            subTime += Time.deltaTime;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag.Equals("bellet"))
        {
            shipHp -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Wall"))
        {
          
            if(RLType == false)
            {
                RLType = true;
                FlipSprite();
            }
            else
            {
                RLType = false;
                BackFlipSprite();
            }
          
        }
    }
    private void FlipSprite()
    {
        spriteRenderer.flipX = true; // ÁÂ¿ì ¹ÝÀü
    }
    private void BackFlipSprite()
    {
        spriteRenderer.flipX = false; // ÁÂ¿ì ¹ÝÀü
    }
}
