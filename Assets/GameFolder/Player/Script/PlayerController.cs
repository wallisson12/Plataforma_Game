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


        //Morte
        if (GetComponent<Character>().life <= 0)
        {
            rb.simulated = false;
            this.enabled = false;
        }


        //Combos e CoolDown
        comboTime = comboTime + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && comboTime > 0.5f)
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
        if (!Input.GetKeyDown(KeyCode.Z))
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

        
        //Pulo Personagem
        canJump = Physics2D.OverlapCircle(floorCollider.position,radius,floorLayer);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            skin.GetComponent<Animator>().Play("PlayerJump", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0,980f));
        }

        //Dash
        dashTime = dashTime + Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) && dashTime > 1)
        {
            audioSource.PlayOneShot(dashSound,0.2f);

            skin.GetComponent<Animator>().Play("PlayerDash",-1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 600f,0));
            dashTime = 0;
        }


    }


     //Visualiza o tamanho do circle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(floorCollider.position,0.3f);
    }

}
