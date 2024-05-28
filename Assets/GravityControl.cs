using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravityControl : MonoBehaviour
{
    public TextMeshProUGUI gravity;
    private ConstantForce2D cForce;
    private Vector2 forceDirection;
    
    void Update()
    {
        
    }

    public void changeGravity(int val)
    {
        if (val == 0)
        {
            
        }
        if (val == 1)
        {
            cForce = GetComponent<ConstantForce2D>();
            forceDirection = new Vector2(0,-10);
            cForce.force = forceDirection;
        }

        if (val == 2)
        {
            cForce = GetComponent<ConstantForce2D>();
            forceDirection = new Vector2(0,-2);
            cForce.force = forceDirection;
        }
        if (val == 3)
        {
            cForce = GetComponent<ConstantForce2D>();
            forceDirection = new Vector2(0,-4);
            cForce.force = forceDirection;
        }
    }

}
