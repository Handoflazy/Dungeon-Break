using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject deathParticle;
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public void SetInactive()
    {
        if(deathParticle) Instantiate(deathParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
    public void DisapearWithPracticle()
    {
        if (deathParticle) Instantiate(deathParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }
    public void DestroyWithPracticle()
    {
        if (deathParticle) Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    public void DisappearAfterTime(float t)
    {
        StartCoroutine(DisappearAfterSeconds(t));
    }
    public IEnumerator DisappearAfterSeconds(float t)
    {
        if (deathParticle) Instantiate(deathParticle, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
    }
}


