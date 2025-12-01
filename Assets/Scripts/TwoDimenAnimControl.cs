using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimenAnimControl : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get input 
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool downPressed = Input.GetKey(KeyCode.S);

        
        //Increase velocity for inputs
        if (forwardPressed && velocityZ < 0.5f )
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (leftPressed && velocityX > -0.5f  )
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velocityX < 0.5f )
        {
            velocityX += Time.deltaTime * acceleration;
        }
        if (downPressed && velocityZ > -0.5f) 
        {
            velocityZ -= Time.deltaTime * acceleration;
        }


        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);


        //Decrease velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        //Increase velocityZ 
        if (!downPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * deceleration;
        }
        //Reset velocityZ
        if (!forwardPressed && !downPressed && velocityZ != 0.0f&& (velocityZ > -0.05f && velocityZ < 0.05f))
        {
            velocityZ = 0.0f;
        }
        //Increase velocityX if left not pressed and velocityX < 0
        if(!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration; 
        }
        //Decrease velocityX if right not pressed and velocityX > 0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }
        //Reset velocityX 
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        
    }
}
