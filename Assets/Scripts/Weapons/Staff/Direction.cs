using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector3 lookDir = (mousePos - transform.position ).normalized;

        float angle2= Mathf.Atan2( lookDir.x, lookDir.y ) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
    }
}
