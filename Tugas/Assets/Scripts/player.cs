using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D body;
    SpriteRenderer sprite;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }
}
