using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private GameObject player;
    private Vector2 playerLocation;

    //public variables-------------------
    public float speed = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = Object.FindObjectOfType<playerController>().gameObject;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);

        //movement to rigidbody to prevent jittering collisions
        rigidbody2d.MovePosition(transform.position);

        /* ------- this code didn't work but has potential to reduce enemy jittering ---------
        playerLocation = player.transform.position;
        Vector2 newPosition = transform.position;
        newPosition = Vector2.MoveTowards(newPosition, playerLocation, speed * Time.deltaTime);
        movement to rigidbody to prevent jittering collisions
        rigidbody2d.MovePosition(newPosition);
        */

        //rigidbody2d.MovePosition(Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime));
    }
}
