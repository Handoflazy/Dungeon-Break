using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] List<string> sceneNames;
    public LayerMask layerMask;
    [SerializeField]
    private string SceneTransitionName;

    private float waitToLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask & (1 << collision.gameObject.layer)) != 0)
        {
            DGSingleton.Instance.SceneManagement.SetTransitionName(SceneTransitionName);
            DGSingleton.Instance.UIfade.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
            
        }
    }
    private IEnumerator LoadSceneRoutine()
    {
        while(waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(sceneNames[0]);
    }
}
