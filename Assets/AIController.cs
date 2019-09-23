using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    float dx = -0.05f;
    SpriteRenderer sr;
    Animator animator;
    int count = 0;
    float waitCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(count / 4 % 2 == 1)
        {
            waitCounter += Time.deltaTime;
            if(waitCounter > 3)
            {
                count = 0;
                waitCounter = 0;
                animator.SetBool("Walk", true);
            }
            return;
        }
        if (transform.position.x < 3 || transform.position.x > 8)
        {
            if (transform.position.x < 3)
                dx = 0.05f;
            else
                dx = -0.05f;

            sr.flipX = dx < 0;
            count++;

            if(count / 4 % 2 == 1)
            {
                animator.SetBool("Walk", false);
                return;
            }
        }
        
        Vector2 pos = transform.position;
        pos.x += dx;
        transform.position = pos;
    }
}
