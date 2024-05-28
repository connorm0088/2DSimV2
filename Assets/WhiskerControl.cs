using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhiskerControl : MonoBehaviour
{
    //public GameObject upperChild;
    //public GameObject lowerChild;
    //public TextMeshProUGUI totalConnections;

    public bool haveLoggedConnection;
    public bool haveMadeOneConnection;
    public string firstConnection;
    public bool haveMadeSecondConnection;
    public string secondConnection;
    public Demo demoScript;
    public int connectionsMade;
    public GameObject UIObject;
    public Renderer objectRenderer;

        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private int conductorCollisions = 0; // Counter to track Conductor collisions

private void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Conductor")
    {
        if (!haveMadeOneConnection)
        {
            firstConnection = collision.gameObject.name;
            haveMadeOneConnection = true;
        }

        if (haveMadeOneConnection && collision.gameObject.name != firstConnection)
        {
            haveMadeSecondConnection = true;
            secondConnection = collision.gameObject.name;

            if (!haveLoggedConnection)
            {
                UIObject.GetComponent<Demo>().connectionsMade += 1; // Increment connectionsMade
                UIObject.GetComponent<Demo>().connectionsPerRun += 1;
                objectRenderer = GetComponent<Renderer>();
                Color newColor = new Color(255, 255, 255);
                objectRenderer.material.color = newColor;

                haveLoggedConnection = true;
            }
        }

        conductorCollisions++; // Increment Conductor collision counter
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Conductor")
    {
        conductorCollisions--; // Decrement Conductor collision counter

        // Only decrement connectionsMade if no more Conductor collisions
        if (haveMadeOneConnection && haveMadeSecondConnection && conductorCollisions <= 0)
        {
            if (UIObject.GetComponent<Demo>().connectionsMade > 0)
            {
                UIObject.GetComponent<Demo>().connectionsMade -= 1;
            } // Reset conductorCollisions to ensure non-negative value
        

        haveMadeOneConnection = false;
        firstConnection = "";

        haveMadeSecondConnection = false;
        secondConnection = "";

            if (haveLoggedConnection)
            {
                haveLoggedConnection = false;
            }
        
        //UIObject.GetComponent<Demo>().connectionsMade -= 1;

        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = Color.yellow;
        }
    }
}
}
