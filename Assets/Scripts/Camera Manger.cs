using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    // Start is called before the first frame update
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 locationOffset;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 desiredPostition = Vector3.zero;

        float deltaX = target.position.x - transform.position.x;
        if(deltaX > boundX|| deltaX< -boundX)
        {
            if(transform.position.x < target.position.x)
            {
                desiredPostition.x = deltaX - boundX;
            }
            else
            {
                desiredPostition.x = deltaX + boundX;
            }
        }
        float deltaY = target.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < target.position.y)
            {
                desiredPostition.y = deltaY - boundY;
            }
            else
            {
                desiredPostition.y = deltaY + boundY;
            }
        }

        desiredPostition += transform.position;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPostition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
