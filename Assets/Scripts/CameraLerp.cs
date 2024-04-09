using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform target;
    [Range(0, 1)] public float smoothSpeed;
    // Start is called before the first frame update

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    private void LateUpdate()
    {

        if (target)
        {
            Vector3 desirePosition = target.position;
            desirePosition.z = -10;

            transform.position = Vector3.Lerp(transform.position, desirePosition, smoothSpeed); 
        }
    }
}
