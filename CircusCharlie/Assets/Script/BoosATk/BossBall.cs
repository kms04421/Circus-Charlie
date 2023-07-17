using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class BossBall : MonoBehaviour
{
    private float subTime;
    // Start is called before the first frame update
    CircleCollider2D circleCollider2D;
    PlayerController playerController;
    Transform target;
    float randX;
    float randY;
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        randX = Random.Range(-1f, -5.5f);


    }

    // Update is called once per frame
    void Update()
    {
        
       
        subTime += Time.deltaTime;

        if (subTime > 1.1)
        {
            transform.Translate(Vector3.zero * 0 * Time.deltaTime);
            circleCollider2D.radius = 0.80f;
        }
        else
        {
            transform.Translate(new Vector3(randX, -2f, 1f) * 1.25f * Time.deltaTime);
        }

        
 
    }
}
