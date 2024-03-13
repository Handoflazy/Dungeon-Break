using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    // Start is called before the first frame update
    [SerializeField] List<string> sceneNames;
    protected override void OnCollide(Collider2D other)
    {
        if(other.name == "Player")
        {
            string sceneName = sceneNames[Random.Range(0, sceneNames.Count)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
