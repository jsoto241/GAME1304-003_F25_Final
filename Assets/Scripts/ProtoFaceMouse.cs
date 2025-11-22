using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoFaceMouse : MonoBehaviour
{
    public LayerMask groundLayer; 

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hit.point;
            //  Keep character upright by matching its y-position
            targetPosition.y = transform.position.y; 
            transform.LookAt(targetPosition);
        }
    }
}