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


public class Demo : MonoBehaviour
{
    public TMP_InputField lengthMean;
    public TMP_InputField lengthStd;
    public TMP_InputField numInput;
    public TMP_InputField condInput;
    public TMP_InputField widthMean;
    public TMP_InputField widthStd;
    public TextMeshProUGUI button;
    public TextMeshProUGUI restart;
    public GameObject whisker;
    public GameObject conductor;
    public TextMeshProUGUI totalConnections;
    public TextMeshProUGUI oddsOfConnect;
    public int connectionsMade;
    public int connectionsPerRun;
    public Text connect;
    public LayerMask obstacleLayer;
    public TMP_InputField totalRuns;
    public float simtimeElapsed;
    public bool startSim;
    public int simIntComplete;
    public float simTimeThresh;
    public float[] oddsArray; 
    
    
    //string fileName = "";
    void Start()
    {
        Time.timeScale = 50f; //50f;
        //whiskerControlScript = GameObject.Find("whisker").GetComponent<WhiskerControl>();
        //fileName = Application.dataPath + "/pullNumber.csv";
    }

    //int i = 0;//new

    void Update()
    {
        simtimeElapsed += Time.deltaTime;

        if(startSim)
        {   
            oddsArray = new float[Convert.ToInt32(totalRuns.text)];//new

            if(simIntComplete < Convert.ToInt32(totalRuns.text))
            {
                
                if(simtimeElapsed > simTimeThresh)
                {
                    RestartWhiskersButton();
                    MakeWhiskerButton();
                   
                    simIntComplete +=1;
                    simtimeElapsed = 0f;
                    //float odds = connectionsPerRun/Convert.ToInt32(numInput.text);// new
                    
                    //oddsArray[i] = 1; //odds;//new
                    //i++; //new
                                                
                    //connectionsPerRun = 0;// new
                     
                }
            }
            if(simIntComplete == Convert.ToInt32(totalRuns.text))
            {
               
            float denom = Convert.ToInt32(totalRuns.text)*Convert.ToInt32(numInput.text);
            float numer = Convert.ToInt32(totalConnections.text);
            
            float totalOdds = numer/denom*100;
            //float minOdds = Mathf.Min(oddsArray);//new
            //float maxOdds = Mathf.Max(oddsArray);//new
            //oddsOfConnect.text = "%" + minOdds.ToString();//new
            oddsOfConnect.text = "%" + totalOdds.ToString(); //undo

            }
        }
        totalConnections.text = connectionsMade.ToString();
    }
public float LengthDistributionGenerate()
    {
        float demo_num1 = RandomFromDistribution.RandomNormalDistribution(float.Parse(lengthMean.text),float.Parse(lengthStd.text));
        return (demo_num1); // logNum1
    }

public float WidthDistributionGenerate()
    {
        float demo_num2 = RandomFromDistribution.RandomNormalDistribution(float.Parse(widthMean.text),float.Parse(widthStd.text));
        return (demo_num2); 
    }


public void RunSimulation()
{
    startSim = true;
    simIntComplete = 0;
}
public void MakeWhiskerButton()
    {
        List<float> lengthDim = new List<float>();
        List<float> widthDim = new List<float>();

        for(int i = 0; i < Convert.ToInt32(numInput.text); i++)
            {
                lengthDim.Add(LengthDistributionGenerate());
                widthDim.Add(WidthDistributionGenerate());


                //TextWriter tw = new StreamWriter(fileName,false);
                //tw.Close();

                //tw = new StreamWriter(fileName, true);

                int spawnPointX = UnityEngine.Random.Range(100,9900);
                int spawnPointY = UnityEngine.Random.Range(500,600);

                //lengths[i] = LengthDistributionGenerate();
                //widths[i] = WidthDistributionGenerate();

                Vector2 spawnPos = new Vector2(spawnPointX,spawnPointY);
                GameObject whiskerClone = Instantiate(whisker,spawnPos,quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
                whiskerClone.tag = "whiskerClone";

                whiskerClone.transform.localScale = new Vector2(WidthDistributionGenerate(),LengthDistributionGenerate());
                //tw.WriteLine(float.lengths[i]);
            }
        
        string filePath = Application.dataPath + "/ExportedNumbers.csv";
        string filepath2 = Application.dataPath + "/ExportedWidth.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        using (StreamWriter writer1 = new StreamWriter(filepath2))
        {
            foreach(float number in lengthDim)
            {
                writer.WriteLine(number);
            }
            foreach(float number in widthDim)
            {
                writer1.WriteLine(number);
            }
        }
    }

public void RestartWhiskersButton()
    {
        GameObject[] allWhiskers;
        allWhiskers = GameObject.FindGameObjectsWithTag("whiskerClone");
       
        foreach (GameObject whisk in allWhiskers)
        {
            //whisk.gameObject.SetActive(false);
            Destroy(whisk.gameObject); // Remove the object from the scene
        }

    }

public void TotalRestart()
    {
        GameObject[] allWhiskers;
        allWhiskers = GameObject.FindGameObjectsWithTag("whiskerClone");
        GameObject[] allConductors;
        allConductors = GameObject.FindGameObjectsWithTag("Conductor");

        foreach (GameObject cond in allConductors)
        {
            Destroy(cond.gameObject);
        }
        
        foreach (GameObject whisk in allWhiskers)
        {
        //    whisk.gameObject.SetActive(false);
            Destroy(whisk.gameObject); // Remove the object from the scene
        }
        
        connectionsMade = 0;
        oddsOfConnect.text = "";
        startSim = false;

    }
}

