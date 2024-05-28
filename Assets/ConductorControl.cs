using UnityEngine;
using TMPro;
using System;
using Unity.Mathematics;
using System.Globalization;
using System.IO;
using System.IO.Enumeration;
using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ConductorControl : MonoBehaviour
{
    public bool isOverlapping;
    public LayerMask overlapLayer;
    public TMP_InputField condInput;
    public GameObject conductor;
    public int conductorCount;
    public int counter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
       
    }
    public void MakeConductorButton()
    {
        for(int i = 0; i < Convert.ToInt32(condInput.text); i++)// i++)
            {
                
                int spawnPointXC = UnityEngine.Random.Range(0,10000);
                int spawnPointYC = UnityEngine.Random.Range(100,100);

                Vector2 spawnCond = new Vector2(spawnPointXC,spawnPointYC);

                GameObject conductorClone = Instantiate(conductor,spawnCond,quaternion.identity);
                
                counter++;
                conductorClone.name = conductor.name + counter;
            }
        Invoke("checkForConductors", 1);
    }
    
    public void OnCollisionStay2D(UnityEngine.Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Conductor"))  //collision.gameObject.tag == "Conductor")
        {
            isOverlapping = true;
            if(isOverlapping)
            {
                GameObject conductorClone = GameObject.FindGameObjectWithTag("Conductor");
                Destroy(conductorClone.gameObject);
            }
        }
    }

    public void checkForConductors()
    {
        GameObject[] allConductors;
        allConductors = GameObject.FindGameObjectsWithTag("Conductor");
        int conductorCounter = allConductors.Length;      

        if(conductorCounter < Convert.ToInt32(condInput.text))   
        {
            MakeConductorButton();
        }
        
        if(conductorCounter > Convert.ToInt32(condInput.text))
        {
            int numOver = conductorCounter - Convert.ToInt32(condInput.text);
            
            for(int i = 0; i < numOver; i++)
            {
                print("deleted");
                GameObject conductorClone = GameObject.FindGameObjectWithTag("Conductor");
                Destroy(conductorClone.gameObject);
            }
        }
    }
}   