using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity = 0.3f;
    SpriteRenderer sr;
    Animator animator;
    string state = "Idle";
    float startY;
    float jumpVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("State is: " + state);
        if(state == "Jump")
        {
            Debug.Log("Jump velocity: " + jumpVelocity);
        }
        if(state == "Jump")
        {
            DoJump();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 pos = this.transform.position;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += velocity;
                sr.flipX = false;

            }
            else
            {
                pos.x -= velocity;
                sr.flipX = true;
            }
            pos.x = Mathf.Clamp(pos.x, -8f, 8f);
            this.transform.position = pos;
            if(state != "Jump")
            {
                state = "Run";
                animator.SetBool("Run", true);
            }
        }
        else
        {
            if (state != "Jump")
            {
                state = "Idle";
                animator.SetBool("Run", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && state != "Jump")
        {
            jumpVelocity = 0.8f;
            state = "Jump";
            DoJump();
            animator.SetBool("Jump", true);
        }
        
    }

    void DoJump()
    {
        float g = -4.2f;
        float dv = g * Time.deltaTime;
        Vector2 pos = this.transform.position;
        pos.y += jumpVelocity;
        if(pos.y < startY)
        {
            pos.y = startY;
            state = "Idle";
            animator.SetBool("Jump", false);
        }
        transform.position = pos;
        jumpVelocity += dv;
    }
}
