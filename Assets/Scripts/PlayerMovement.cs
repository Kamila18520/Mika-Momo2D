using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    [SerializeField] private int jumpMeter = 0;


    [SerializeField] private LayerMask jumpableGround;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 7f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //RAW robi ¿e zakoñczenie chodzenia bedzie od razu, bez tego bêdzie p³ynniejsze ale po zakonczeniu przyciskania Key poruszy sie troszke dalej
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);



        if (Input.GetButtonDown("Vertical") && jumpMeter == 0 )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpMeter++;

            if(IsGrounded())
            { jumpMeter--; }

        }
        else if (Input.GetButtonDown("Vertical") && jumpMeter == 1 && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpMeter=0;
        }
        //else jumpMeter = 0;

        UpdateAnimationState();
    
        }

    private void UpdateAnimationState()
    {
           if ( dirX < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            } 
    }

    private bool IsGrounded()
    {
        
         return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
        
    }
}
