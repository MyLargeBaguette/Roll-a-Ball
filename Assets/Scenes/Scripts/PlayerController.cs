using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    int totalPickups;
    int pickupcount;
    Timer timer;
    bool wonGame = false;

    [Header("UI")]
    public GameObject winPanel;
    public TMP_Text winTime;
    public GameObject inGamePanel;
    public TMP_Text timerText;
    public TMP_Text pickupText;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigid body componant of the game object
      rb = GetComponent<Rigidbody>();
        //get max num of pickups in le scene
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;
        pickupcount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        CheckPickups();
        //get timer object + start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
        //turn off win panel
        winPanel.SetActive(false);
        //turn on wingame panel
        inGamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (wonGame == true)
            return;
        // get input value from horizontal axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        // get input value from vertical axis
        float moveVertical = Input.GetAxis("Vertical");

        // get vector values based on H or V Values
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // add force to rigid body based on movement vector
        rb.AddForce(movement * speed);

        timerText.text = "You Fast? " + timer.GetTime().ToString("F2");
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
        // Debug.Log("Pickups Left: " + pickupcount);
        pickupText.text = "Pickup your Game: " + pickupcount + "/" + totalPickups;
        if (pickupcount == 0)
        {
            WinGame();
        }
    }

void WinGame()
    {
        wonGame = true;
        timer.StopTimer();
       // Debug.Log("Dayum Home Slizzle you goshdarn won and stuff! Get Faster Loser- " + timer.GetTime().ToString("F2"));
        //set timer on  text
        winTime.text = "Get Faster Loser- " + timer.GetTime().ToString("F2");
        //turnoff ingame panel
        inGamePanel.SetActive(false);
        //Turn on win panel
        winPanel.SetActive(true);
    }
    //TEMP REMOVE WHEN DOING MODULES IN A2

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }


}
