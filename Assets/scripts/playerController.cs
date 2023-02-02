using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vert;

    bool canBeDamaged = true;
    public float timeInvincible = 1.5f;
    float invincibleTimer;

    public int maxHealth = 10;
    int health;

    //public variables-------------------
    public float speed = 0.2f;

    //Animation
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement axes
        horizontal = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vert);
        
    //if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
    //{
        lookDirection.Set(move.x, move.y);
        lookDirection.Normalize();
    //}
        
        animator.SetFloat("X", lookDirection.x);
        animator.SetFloat("Y", lookDirection.y);
        animator.SetFloat("", move.magnitude);


         //if you can be damaged (not invincible), then count down invincibility timer
        if(!canBeDamaged)
        {
            invincibleTimer -= timeInvincible * Time.deltaTime;
            if(invincibleTimer < 0)
            {
                canBeDamaged = true;
            }
        }
       
    }

    void FixedUpdate()
    {
        //movement to rigidbody to prevent jittering collisions
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vert * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

     void OnCollisionStay2D(Collision2D col)
    {

        //if you collide with an enemy, start timer, decrease health, and check for game over (if health < 0)
        if(col.gameObject.tag == "enemy" && canBeDamaged)
        {
            Debug.Log("ENEMY HIT YOU");
            Debug.Log(health);
            canBeDamaged = false;
            invincibleTimer = timeInvincible;
            health--;
            if(health <= 0)
            {
                GameOver();
            }
        }
        
    }

     void GameOver()
    {
        Debug.Log("Game Over. Health: " + health);
    }
}
