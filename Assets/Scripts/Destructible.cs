using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
    public void DisapearWithPracticle(GameObject Particle)
    {
        Instantiate(Particle, transform.position, Quaternion.identity);
    }
}


