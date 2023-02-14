using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using UnityEditor.Search;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
   public string WinMessage = "You are Win";
        int counter = 0;
    public int WinAmount;

    void Start()
    {
        ShowMessage();
        Debug.Log(WinMessage);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            counter++;
            if (counter == WinAmount)
            {
                ShowMessage();
            }
        }
    }
    void ShowMessage()
    {
        Debug.Log(WinMessage + " " + counter + " times");
    }
}
