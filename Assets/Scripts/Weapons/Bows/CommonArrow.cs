using SunnyValleyVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(DamageSource))]
public class CommonArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    public float Distance { get; set; }
    private float flyDistance = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        flyDistance = 0;
    }
    private void Update()
    {
        MoveProjectle();
    }

    void MoveProjectle()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        flyDistance += speed * Time.deltaTime;
        if (flyDistance > Distance)
        {
            gameObject.SetActive(false);
        }
    }
}
