using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject belletPrefab;
    private GameObject[] bellet;
    private int belletCount;

    public AudioClip dieClip;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        bellet = new GameObject[20];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAudio.PlayOneShot(dieClip);
            bellet[belletCount] = Instantiate(belletPrefab,gameObject.transform.position, Quaternion.identity);
         
         
            Destroy(bellet[belletCount], 2);
            belletCount++;
        }
      
    }
}
