using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountClick : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
