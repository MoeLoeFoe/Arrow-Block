using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    
   
    [SerializeField] private float moveSpeed;
    private bool hitground = false;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool alrdytookAheart=false;
   
   
    void Start()
    {

        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<BoxCollider2D>();
     
    }

   
    void Update()
    {

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        if (!hitground)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("normalarrow"))
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                hitground = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                coll.isTrigger = true;
                Destroy(this.gameObject, 1f);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
               

            }
            else if (collision.gameObject.CompareTag("drawnwall"))
            {
                BillyLife.arrowbreaksound.Play();
                Destroy(this.gameObject);
            }
        }else if (this.gameObject.CompareTag("vegetable"))
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                hitground = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                coll.isTrigger = true;
                if (transform.position.x < BillyMovement.BillysX)
                {
                    BillyMovement.left = true;
                    BillyMovement.right = false;
                }
                else
                {
                    BillyMovement.right = true;
                    BillyMovement.left = false;
                }
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
               
              
            }
            else if (collision.gameObject.CompareTag("drawnwall") &&!alrdytookAheart)
            {
                alrdytookAheart = true;
                Destroy(this.gameObject);
                BillyLife.TakeHeart(true);
                BillyLife.hurtsound.Play();

            }
        }
        


    }
}
