using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Mover
{
    
   

    // Update is called once per frame
   
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
       
        Vector3 input = new Vector3(horizontalInput, verticalInput,0);
        UpdateMotor(input.normalized);
    }
  
}
