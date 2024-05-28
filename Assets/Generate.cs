using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class Generate : MonoBehaviour
{
    public GameObject whisker;
    // Start is called before the first frame update
    public void MakeWhiskerButton()
    {
        Instantiate(whisker);

        //whisker.transform.localScale = new Vector2(1f,DistributionGenerate());
    }

}
