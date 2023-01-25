using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vert;

    //public variables-------------------
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement axes
        horizontal = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
       
    }

    void FixedUpdate()
    {
        //movement to rigidbody to prevent jittering collisions
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vert * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
