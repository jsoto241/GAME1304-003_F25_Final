using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableWeapon()
    {
        weaponCollider.enabled = true;
    }
    public void DisableWeapon()
    { 
        weaponCollider.enabled = false;
    }
}
