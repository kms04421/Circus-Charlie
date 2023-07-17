using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belletMove : MonoBehaviour
{
    public float speed = 10f;
    public bool RL = true;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController1.instance.RLType == true)
        {
            RL = true;
        }
        else {
            RL = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(RL == true)
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);

        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag.Equals("Boss"))
        {
            Destroy(gameObject);
        }
        else if(collision.tag.Equals("ship"))
        {
            Destroy(gameObject);
        }
        
        
    }
}
