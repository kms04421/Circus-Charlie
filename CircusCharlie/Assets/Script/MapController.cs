using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update

    private bool isDead = false;
    private bool canMove = true;



    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) { return; }
        if (GameManager.instance.isGameClear == true) { return; }
      

        if (!Input.GetButtonDown("Jump"))
        {  }
    
        if (GameManager.instance.isGameOver == false)
        {
            Debug.Log("W");
            float horizontalInput = Input.GetAxis("Horizontal");
            float movement = horizontalInput * moveSpeed * Time.deltaTime;

            // 반대 방향으로 이동
            transform.Translate(Vector3.right * -movement);
        }
        else
        {
            Debug.Log("x");
            transform.Translate(Vector3.right * 0);
        }

          
        
       
        

        
    }
   
}
