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

    public Transform Check;
    public float RadioCheck;
    public bool TocandoPiso;
    public LayerMask QueesPiso;


    private enum MovementState
    {
        idle, running, jumping, falling
    }

    

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

        if (Input.GetKeyDown("w") && TocandoPiso == true) { 
            
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            
        }
        UpdateAnimationUpdate();

        TocandoPiso = Physics2D.OverlapCircle(Check.position,RadioCheck,QueesPiso);

    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if(dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle; ;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }
 // private bool IsGrounded() 
 // {
 // return Physics2D.BoxCast(Cooldown.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    
 // }
}
