using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Start()
    {
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;

       
    }

     private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider)
            {
                Debug.Log("ï«Ç∆ê⁄êGÇµÇΩÅI");
            }
        }
}
