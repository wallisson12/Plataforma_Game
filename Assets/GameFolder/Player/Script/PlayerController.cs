using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public LayerMask floorLayer;
    public Transform floorCollider;
    public Transform skin;
 

    public PhysicsMaterial2D material;

    public bool canJump;

   public int comboNum;
   public float comboTime;

    public float dashTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Morte
        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
        }


        //Combos e CoolDown
        comboTime = comboTime + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && comboTime > 0.5f)
        {
            comboNum++;
            if (comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);
            GetComponent<Rigidbody2D>().sharedMaterial.friction = 1000f;
        }

       
        if (comboTime >= 1)
        {
            comboNum = 0;
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
          canJump = Physics2D.OverlapCircle(floorCollider.position,0.1f,floorLayer);

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
            skin.GetComponent<Animator>().Play("PlayerDash",-1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(skin.localScale.x * 600f,0));
            dashTime = 0;
        }
    }
}
