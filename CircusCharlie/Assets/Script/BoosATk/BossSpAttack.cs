using UnityEngine;
using UnityEngine.UI;
public class BossSpAttack : MonoBehaviour
{
    public GameObject SpBoossATKReady;
    public GameObject RotaBeam;
    public GameObject Boosball;
    private Animator animator;
    public Image BoosHPBar;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 2.5f;
    private float spawnRate;
    private float fullTimeAfterSpawn;
    float LastAtkTime;
    private PlayerController1 target;
    private bool LastAtk = false;
    GameObject ATKReady;
    private int AtkCount = 0;
    int randAtk;
    bool ATkon = false;
    bool rotaChk = false;
    private float subTime;
    bool start = false;
    float boosHp = 1;
    public bool boosAtk = false;
    public bool boosAtkMove = false;
    private bool boosDie = false;
    bool invincibility = false;

    public AudioClip ATk1;
    public AudioClip ATk2;
    public AudioClip ATk3;
 
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController1>();
        spawnRate = 10;
        randAtk = Random.Range(0, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        fullTimeAfterSpawn += Time.deltaTime;

        if (boosHp < 0 &&  boosDie == false)
        {
            GameManager.instance.GameClear();
            animator.SetTrigger("BoosDie");
            boosDie = true;
        }
        if(fullTimeAfterSpawn > 2 && boosDie ==true)
        {
            gameObject.SetActive(false);
        }
        if(boosDie == true )
        {
            return;
        }
        Vector2 vector2 = new Vector2(target.transform.position.x + 3, 0);
       
       
        if (start == false)
        {
            boosAtk = true;
            animator.SetBool("BoosAtk", boosAtk);
            if(fullTimeAfterSpawn > 2)
            {
                start = true;
                fullTimeAfterSpawn = 0f;
            }
            
           
        }


        if(start == true)
        {
         

            //타겟 레이저 공격
            if (fullTimeAfterSpawn <= spawnRate && randAtk == 0)
            {

                spawnRate = 5;
                subTime += Time.deltaTime;

                if (subTime > 1)
                {

                    playerAudio.PlayOneShot(ATk1);
                    targetBoosAttack(vector2);
                    AtkCount++;
                    subTime = 0;
                }

                if (AtkCount > 3)
                {
                    playerAudio.Stop();
                    boosAtk = false;
                    animator.SetBool("BoosAtk", boosAtk);
                    fullTimeAfterSpawn = 0f;
                    AtkCount = 0;
                    randAtk = Random.Range(1, 3);                   
                    start = false;
                }

            }
            //일자 레이저 공격
            if (fullTimeAfterSpawn <= spawnRate && randAtk == 1)
            {
                float rotationAmount = 10 * Time.deltaTime;
          
                if (ATkon == false)
                {
                    
                    invincibility = true;
                    RotaBeamAtk();
                    ATkon = true;
                    
                }

                playerAudio.PlayOneShot(ATk2);
                spawnRate = 12;
                subTime += Time.deltaTime;
                if (subTime > 1)
                {
                    AtkCount++;
                    subTime = 0;

                }

                if (AtkCount < 5)
                {
                    transform.Rotate(Vector3.forward, rotationAmount);
                }
                else if (AtkCount > 5)
                {
                    transform.Rotate(Vector3.forward, -rotationAmount);
                }


                if (AtkCount >= 11)
                {
                    playerAudio.Stop();
                    boosAtk = false;
                    animator.SetBool("BoosAtk", boosAtk);
                    fullTimeAfterSpawn = 0f;
                    ATkon = false;
                    AtkCount = 0;
                    randAtk = Random.Range(0, 3);
                    start = false;
                    invincibility = false;
                }

            }
            //전기공 공격
            if (fullTimeAfterSpawn <= spawnRate && randAtk == 2)
            {

                spawnRate = 4;
                subTime += Time.deltaTime;

                if (subTime > 1)
                {

                    playerAudio.PlayOneShot(ATk3);
                    BossBallAtk();
                    AtkCount++;
                    subTime = 0;
                }

                if (AtkCount > 2)
                {
                    boosAtk = false;
                    animator.SetBool("BoosAtk", boosAtk);
                    fullTimeAfterSpawn = 0f;
                    AtkCount = 0;
                    randAtk = Random.Range(0, 3);
                    start = false;
                }
            }
        }

      
      
    }

    public void targetBoosAttack(Vector2 vector2)
    {
        ATKReady = Instantiate(SpBoossATKReady, vector2, Quaternion.identity);

        Destroy(ATKReady, 3);

    }

    public void RotaBeamAtk()
    {


        Vector2 startBeam = new Vector2(0.51f, 2.31f);
        GameObject BossAtk = Instantiate(RotaBeam, startBeam, Quaternion.identity);

        BossAtk.transform.parent = gameObject.transform;

        Destroy(BossAtk, 10);


    }

    public void BossBallAtk()
    {
        GameObject boosball = Instantiate(Boosball);

        Destroy(boosball, 1.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("bellet") && invincibility == false)
        {
            boosHp -= 0.01f;
            BoosHPBar.fillAmount -= 0.01f;
            
        }
    }
 
}
