using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    EntityStats status_player;
    float move_speed;

    Animator animator_;
    // Start is called before the first frame update
    void Start()
    {
        status_player = gameObject.GetComponent<EntityStats>();
        move_speed = status_player.base_speed;
        animator_ = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move ();
    }

    void Move ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw ("Vertical");
        gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2(horizontal * move_speed, vertical * move_speed));
        
        //Movimento diagonal
        if ((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0))
        {
            move_speed = status_player.base_speed * 0.66f;
            
        }
        else 
        {
            move_speed = status_player.base_speed;
        }

        //Animação
        if (horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
        {
            if (horizontal < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else 
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            animator_.Play("Move");
            
        }
        else 
        {
            animator_.Play("Idle");
        }
    }
}
