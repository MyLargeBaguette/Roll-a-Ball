using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    int pickupcount;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigid body componant of the game object
      rb = GetComponent<Rigidbody>();
        //get max num of pickups in le scene
        pickupcount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        CheckPickups();
        //get timer object + start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
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


    void OnTriggerEnter(Collider other)
    {
        // If other object contains pick up tag, delete it from existance
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            // lower pickup count by one
            pickupcount -= 1;
            CheckPickups();
        }


    }

    void CheckPickups()
    {
        Debug.Log("Pickups Left: " + pickupcount);

        if (pickupcount == 0)
        {
            WinGame();
        }
    }

void WinGame()
    {
        timer.StopTimer();
        Debug.Log("Dayum Home Slizzle you goshdarn won and stuff! Get Faster Loser- " + timer.GetTime().ToString("F2"));
    }


}
