using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    public float speed2;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigid body componant of the game object
      rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        // get input value from horizontal axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        // get input value from vertical axis
        float moveVertical = Input.GetAxis("Vertical");

        // get vector values based on H or V Values
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // add force to rigid body based on movement vector
        rb.AddForce(movement * speed);
    }
}
