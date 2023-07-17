using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    public Text scoreText;
    public TMP_Text MmText;
    public bool isGameClear = false;
    public GameObject gameClear;
    public GameObject gameOver;
    public GameObject fireRing;
    public int stage = 1;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

   
    private int life = 3;
    float subTime;
    private void Awake()
    {
        if(instance == null)
        {
           
            instance = this;
        }
        else
        {
            Debug.Log(instance);
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("life"))
        {
            life = PlayerPrefs.GetInt("life");
        }
      
        
    }

    private int score = 0;
    public int meter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(life);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && life != 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                life -= 1;
                PlayerPrefs.SetInt("life", life);
                PlayerPrefs.Save();
                if(stage == 1)
                {
                    SceneManager.LoadScene("1Stage");
                }else
                {
                    SceneManager.LoadScene("2Stage");
                }
                
            }
        }
        if(isGameClear == true)
        {
            Debug.Log("2");  
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("2Stage");
            }
        }
       

        if (life >= 3)
        {

        }
        if (life <= 2)
        {
            life3.SetActive(false);
            
        }
        if(life <= 1)
        {
            life2.SetActive(false);
        }
        if (life <= 0)
        {
            life1.SetActive(false);
        }
        if (life == 0 && isGameOver ==true)
        {

            PlayerPrefs.DeleteKey("life");
        }
    }
    public void AddScore(int newScore)
    {
        
            if (isGameOver == false)
            {
                score += newScore;
                scoreText.text = string.Format("1P : {0}", score);
            }
        
       
    }

    public void OnplayerDead()
    {
        isGameOver = true;
        gameOver.SetActive(true);
        fireRing.SetActive(false);
    }
    public void AddMM(int mm)
    {

        if (isGameOver == false)
        {
            meter += mm;
            MmText.text = string.Format("{0} M", meter);
        }
    }
    public void GameClear()
    {
        isGameClear = true;
        gameClear.SetActive(true);
        fireRing.SetActive(false);

    }

    public void StageSet(int stageNumber)
    {
        stage = stageNumber;
    }
}
