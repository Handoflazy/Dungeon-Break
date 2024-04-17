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
    public void DisappearAfterTime(float t)
    {
        StartCoroutine(DisappearAfterSeconds(t));
    }
    public IEnumerator DisappearAfterSeconds(float t)
    {

        yield return new WaitForSeconds(t);
        if (deathParticle) Instantiate(deathParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}


