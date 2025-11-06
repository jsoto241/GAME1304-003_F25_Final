using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isMovingHash; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isMovingHash = Animator.StringToHash("isMoving"); 
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = animator.GetBool(isMovingHash); 
        bool forwardPressed = Input.GetKey("w");  

        // Press w
        if (!isMoving && forwardPressed)
        {
            // Set isMoving to true
            animator.SetBool(isMovingHash, true);
        }
        
        // w not Pressed
        if (isMoving && !forwardPressed)
        {
            // Set isMoving to false
            animator.SetBool(isMovingHash, false); 
        }
    }
}