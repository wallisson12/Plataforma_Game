using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public bool canJump;

    public LayerMask floorLayer;
    public Transform floorCollider;
    public float radius = 0.3f;
    public Transform skin;


    public static PlayerController insta;

    public int comboNum;
    public float comboTime;
    public float dashTime;

    public string currentLevel;

    public AudioSource audioSource;

    public AudioClip dashSound;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip heartSound;
    public AudioClip gameover;

    public Transform gameOverScreen;
    public Transform pauseScreen;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;

        if (insta != null)
        {
            Destroy(this.gameObject);
            return;
        }

        insta = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        
        //Coleta o nome da scene atual
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        }

        //Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }

        //Morte
        if (GetComponent<Character>().life <= 0)
        {
            if (GetComponent<Character>().Cam.GetComponent<AudioSource>().clip != gameover)
            {
                GetComponent<Character>().Cam.GetComponent<AudioSource>().clip = gameover;
                GetComponent<Character>().Cam.GetComponent<AudioSource>().PlayOneShot(gameover,1f);
            }

            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;

        }


        //Pulo Personagem
        Jump();

        //Dash
        Dash();

        //Combos e CoolDown
        comboTime = comboTime + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X) && comboTime > 0.5f)
        {
            //Para nao deslizar enquanto bate
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            comboNum++;
            if (comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);

            //Executa o som
            if (comboNum == 1)
            {
                audioSource.PlayOneShot(attack1Sound,0.5f);
            }
            else if(comboNum == 2)
            {
                audioSource.PlayOneShot(attack2Sound, 0.5f);
            }
        }

        //Para nao deslizar enquanto bate
        if (!Input.GetKeyDown(KeyCode.X))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

    
        //Animacoes e Flip
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"),1,1);
            skin.GetComponent<Animator>().SetBool("PlayerRun",true);

        }else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun",false);
            
        }

    }

    private void FixedUpdate()
    {
        if (comboTime > 0.5f && dashTime > 0.3)
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5f, rb.velocity.y);

        }

    }

    public void Jump()
    {
        //Pulo Personagem
        canJump = Physics2D.OverlapCircle(floorCollider.position, radius, floorLayer);

        if (Input.GetKeyDown(KeyCode.Z) && canJump)
        {
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, 980f));
        }
    }

    public void Dash()
    {
        //Dash
        dashTime = dashTime + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.C) && dashTime > 1)
        {
            audioSource.PlayOneShot(dashSound, 0.2f);

            skin.GetComponent<Animator>().Play("PlayerDash", -1);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            Invoke("RestoreGravity",0.3f);
            rb.AddForce(new Vector2(skin.localScale.x * 600f, 0));
            dashTime = 0;
        }
    }

    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }

    void RestoreGravity()
    {
        rb.gravityScale = 6f;
    }

     //Visualiza o tamanho do circle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(floorCollider.position,0.3f);
    }

}
