using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpforce = 14f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX *movespeed, rb.velocity.y);

        if (Input.GetKeyDown("w")) { 
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        UpdateAnimationUpdate();

    }
    private void UpdateAnimationUpdate()
    {
               if(dirX > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("Running" , true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }

    }
 // private bool IsGrounded() 
 // {
 // return Physics2D.BoxCast(Cooldown.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    
 // }
}
