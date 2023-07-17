using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossLastAtk : MonoBehaviour
{
    public GameObject SpAttackLast;
    private float timeAfterSpawn;
    private bool atchk = false;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
       
        if (timeAfterSpawn >= 2 )
        {
          
            timeAfterSpawn = 0;
            Vector2 vector2 = new Vector2(gameObject.transform.position.x - 3.75f, gameObject.transform.position.y -1f);
            GameObject ATKLast = Instantiate(SpAttackLast, vector2, Quaternion.identity);

            Destroy(ATKLast, 1);
        }
    }
}
