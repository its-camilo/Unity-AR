using System;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private FixedJoystick fixedJoystick;
    private Rigidbody rb;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;
        
        Vector3 direction = new Vector3(xVal, 0, yVal);
        rb.velocity = direction * speed;
        
        if (xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}
