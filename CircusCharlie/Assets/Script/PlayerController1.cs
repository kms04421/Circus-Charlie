using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public static PlayerController1 instance;
    public float jumpForce = 400f;
    public float moveSpeed = 10f;
    public int jumpCount = 0;
    
    private bool isGrounded = true;
    private bool isDead = false;
    public SpriteRenderer spriteRenderer;

    private Animator animator = default;
    Rigidbody2D playerRigid = default;
    public bool RLType = true;


    public AudioClip dieClip;
    public AudioSource playerAudio;
    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
        }
        else
        {
            Debug.Log(instance);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.instance.StageSet(2);
    }
    // Update is called once per frame
    void Update()
    {
       // if (GameManager.instance.isGameClear == true) { return; }

        if (isDead == true) { return; }
        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");


       if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RLType = false;
            FlipSprite();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RLType = true;
            UnFlipSprite();
        }
   

    float movement = horizontalInput * 5 * Time.deltaTime;

        // 반대 방향으로 이동
        transform.Translate(Vector3.right * movement);
        animator.SetBool("Ground", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.tag);
        if (collision.tag.Equals("Dead"))
        {
            Die();
        }
       
    }
    private void Die()
    {

        animator.SetTrigger("Die");
        if(isDead == false)
        {
           
            playerAudio.PlayOneShot(dieClip);
        }

        playerRigid.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnplayerDead();



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.collider.tag.Equals("Floor"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
  

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        isGrounded = false;


    }

    private void FlipSprite()
    {
        spriteRenderer.flipX = true; // 좌우 반전
    }
    private void UnFlipSprite()
    {
        spriteRenderer.flipX = false; // 좌우 반전
    }
}
