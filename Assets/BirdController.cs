using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    float dx = 0.1f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -15 || transform.position.x > 15)
        {
            if (transform.position.x < -15)
                dx = 0.1f;
            else
                dx = -0.1f;
            sr.flipX = transform.position.x > 15;
        }

        Vector2 pos = transform.position;
        pos.x += dx;
        transform.position = pos;
    }
}
