using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest : MonoBehaviour
{

    public ConstantForce2D Force2;
    public Rigidbody2D rb;
    public int number;
    private Vector2 forceDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
        Force2.relativeForce = new Vector2(-Force2.relativeForce.x,Force2.relativeForce.y);

           if(Input.GetKeyDown(KeyCode.Space))
           {ForceTestOne(2);}
    }
    public void ForceTestOne(int number)
    {
        int i = 10;
        number = i*2;
        
        float number2 = Mathf.Sin(number);
            //print(number2);
            //Force2 = GetComponent<ConstantForce2D>();
        forceDirection = new Vector2(0,number2);

        rb.AddForce(forceDirection*number2);

     //for (int i = 0; i < 10; i++)
       // {
           

             //float number2 = Mathf.Sin(number);
                //print(number2);
                //Force2 = GetComponent<ConstantForce2D>();
                //forceDirection = new Vector2(0,number2);
                //Force2.force = forceDirection;

           //print(number2); 
       // }
    }


}
