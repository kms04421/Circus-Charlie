using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoos : MonoBehaviour
{
    // Start is called before the first frame update
    private float subTime;
    public GameObject Boos;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        subTime += Time.deltaTime;

        if (subTime > 2)
        {
            gameObject.SetActive(false);
            Boos.SetActive(true);
        }
    }
}
