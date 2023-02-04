using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake(){
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force){
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other){
        //Debug.Log(other.gameObject);
        if(other.gameObject.tag == "enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
