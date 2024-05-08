using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BillyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public static bool right, left;
    public static float BillysX;
    private float moveSpeed = 5f;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI diaText;
    [SerializeField] private Animator DiaAnim;
    [SerializeField] private Canvas DialogueBox;
    private float xOfDiaBox,yOfDiaBox;
    public static int r = -1;
    private bool stopslurring = false;
    [SerializeField] private BillyLife lifescript;
    private void Awake()
    {
        right = false; left = false;
        xOfDiaBox = DialogueBox.transform.localPosition.x;
        yOfDiaBox = DialogueBox.transform.localPosition.y;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        

        InvokeRepeating("GenerateRandomR", 1f, 3f);


    }
    private int GenerateRandomR()
    {
        stopslurring = false;
        if (r == -1)
        {
            r = 3;
        }
        else
        {
            r = Random.Range(0, 4); // random int between (0,1,2,3)
        }
        
        
        return r;
    }

    public void playIdle()
    {
        stopslurring = true;
        anim.Play("IdleSide");

    }
    void Update()
    {
      
        BillysX = transform.position.x;
        if (!BillyLife.hurtorvanish)
        {
            if (!right && !left)
            {
                if (r == 0 || r == 3) // run or walk
                {
                    if (r == 3)
                    {
                        anim.Play("RunSide");
                        moveSpeed = 8f;
                    }
                    else
                    {
                        anim.Play("WalkSide");
                        moveSpeed = 5f;
                    }

                    if (sr.flipX == false) // going left
                    {
                        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                        DialogueBox.transform.localPosition = new Vector2(-xOfDiaBox, yOfDiaBox);

                    }
                    else //going right
                    {
                        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                        DialogueBox.transform.localPosition = new Vector2(xOfDiaBox, yOfDiaBox);
                    }

                }
                else if (r == 1||r==2)//idle
                {
                    rb.velocity = new Vector2(0f, 0f);
                    anim.Play("IdleSide");
                }
                
            } else if (right)
            {
                sr.flipX = true;
                anim.Play("RunSide");
                moveSpeed = 8f;
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            } else if (left)
            {
                sr.flipX = false;
                anim.Play("RunSide");
                moveSpeed = 8f;
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }

        }


    }

    
    public void TurnIsOpenOff()
    {
        DiaAnim.SetBool("IsOpenRight", false);
        DiaAnim.SetBool("IsOpenLeft", false);
        diaText.enabled = false;
    }
    public void turnDiaTextOn()
    {
        diaText.enabled = true;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inviswall"))
        {
            if (sr.flipX == true)
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), rb.velocity.y);
            }
            else
            {
                sr.flipX = true;
                rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), rb.velocity.y);
            }
        } else if (collision.gameObject.CompareTag("normalarrow") || collision.gameObject.CompareTag("vegetable"))
        {
            Destroy(collision.gameObject);
            rb.velocity = Vector3.zero;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("vegetable"))
        {
           
            Destroy(collision.gameObject);
            right = false; left=false;
          
        }
    }

    

}
