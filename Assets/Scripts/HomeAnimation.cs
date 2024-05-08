using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeAnimation : MonoBehaviour
{
    private float walkSpeed = 5f, crawlSpeed = 2f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool walking=true,alrdycrawling=false;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>(); 
    }

  
    void Update()
    {
        if (!sr.flipX) // going left
        {
            if (walking)
            {
                rb.velocity = new Vector2(-walkSpeed, 0f);
                anim.Play("WalkSide");
            }
            else
            {
                rb.velocity = new Vector2(-crawlSpeed, 0f);
                anim.Play("crawl_side");
            }
            
        }
        else // going right
        {
            if (walking)
            {
                rb.velocity = new Vector2(walkSpeed, 0f);
                anim.Play("WalkSide");
            }
            else
            {
                rb.velocity = new Vector2(crawlSpeed, 0f);
                anim.Play("crawl_side");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "inviswall")
        {
            if (!sr.flipX)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "crawlwall")
        {
            if (alrdycrawling) // go from crawl to walk
            {
                walking = true;
                alrdycrawling = false;
            }
            else // go from walk to crawl
            {
                walking = false;
                alrdycrawling = true;
            }
        }
    }
}
