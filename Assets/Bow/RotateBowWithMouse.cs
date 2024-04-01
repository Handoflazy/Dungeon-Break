using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.localScale.x == -1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (transform.parent.localScale.x == 1)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        // Xác định hướng của chuột
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = (mousePosition - transform.position).normalized;

        // Xoay Object để nhìn theo hướng của chuột
        float angle2 = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));
    }
}

