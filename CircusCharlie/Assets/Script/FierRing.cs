using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FierRing : MonoBehaviour
{
    public GameObject fierRingPrefab;
    public int count = 3;
    public GameObject parents;
    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 4f;

    private float timeBetSpawn;

   
    private float xPos = 20f;

    private GameObject[] fierRing;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25f);
    private float lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        fierRing = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            fierRing[i] = Instantiate(fierRingPrefab, poolPosition, Quaternion.identity);
            
        }
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.instance.isGameOver)
        {
            return;
        }*/
        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);


           
            fierRing[currentIndex].SetActive(true);
            fierRing[currentIndex].transform.parent = parents.transform;
            fierRing[currentIndex].transform.position = new Vector2(xPos, 2);
            currentIndex += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }

        }
    }
}
