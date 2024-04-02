using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMoving_Ref : MonoBehaviour
{
    public int scenceBuiltIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");
        if (other.tag == "Player")
        {
            print("Switching Scence to " + scenceBuiltIndex);
            SceneManager.LoadScene(scenceBuiltIndex, LoadSceneMode.Single);
        }
    }
}
