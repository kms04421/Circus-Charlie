using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpwon : MonoBehaviour
{
    private float fullTimeAfterSpawn;
    public GameObject ShipObject;

    float randSpwanTime;
    // Start is called before the first frame update
    void Start()
    {
        randSpwanTime = Random.Range(10f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        fullTimeAfterSpawn += Time.deltaTime;

        if(fullTimeAfterSpawn > randSpwanTime)
        {
            GameObject instanShip = Instantiate(ShipObject,new Vector2(gameObject.transform.position.x,gameObject.transform.position.y),Quaternion.identity);
            Destroy(instanShip, 20f);
            fullTimeAfterSpawn = 0;
            randSpwanTime = Random.Range(10f, 20f);
        }
        
    }
}
