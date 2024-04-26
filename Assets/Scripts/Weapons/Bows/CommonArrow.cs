using SunnyValleyVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(DamageSource))]
public class CommonArrow : MonoBehaviour
{
    [SerializeField] float speed;
    public float Distance { get; set; }
    private float flyDistance = 0;
    private void OnEnable()
    {
        flyDistance = 0;
        GetComponent<TrailRenderer>().emitting = true;
    }
    private void Update()
    {
        MoveProjectle();
    }
    private void Start()
    {
       
    }

    void MoveProjectle()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        flyDistance += speed * Time.deltaTime;
        if (flyDistance > Distance)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
        GetComponent<TrailRenderer>().emitting = false;
    }
}
