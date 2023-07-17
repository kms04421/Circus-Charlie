using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLoop : MonoBehaviour
{
    int count = 0;
    int UnCount = 0;
    private float width;
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
       

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -width)
        {
            Reposition();
            if (count > 1)
            {
                GameManager.instance.AddMM(10);
                count = 0;
            }
        }
        if (transform.position.x >= width)
        {
            UnReposition();
            if (UnCount > 1)
            {             
                GameManager.instance.AddMM(-10);
                UnCount = 0;
            }
            
        }
       

    }
    private void Reposition()
    {
        count++;
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position =(Vector2)transform.position + offset;
       
    }
    private void UnReposition()
    {
        UnCount++;
        Vector2 offset = new Vector2(width * -2f, 0f);
        transform.position = (Vector2)transform.position + offset;

    }
}
