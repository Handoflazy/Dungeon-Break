using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Camera cam;
    private Vector2 startPos;
    [SerializeField] private float parallaxOffset = -0.15f;

    private Vector2 travel => (Vector2)cam.transform.position- startPos;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {
        startPos = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = startPos + travel* parallaxOffset;
    }
}
