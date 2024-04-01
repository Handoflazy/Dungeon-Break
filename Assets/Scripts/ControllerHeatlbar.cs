using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHealthbar : MonoBehaviour
{
    [SerializeField]
    Transform enemmyTransform;

    Vector3 normalLocalScale;
    private float rateSize;
    // Start is called before the first frame update
    private void Start()
    {
        rateSize = transform.localScale.y;
        normalLocalScale = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (enemmyTransform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-normalLocalScale.x, normalLocalScale.y, normalLocalScale.z);
        }
        else
            transform.localScale = normalLocalScale;
    }
}
