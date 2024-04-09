using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    public static SingletonExample instance;
    public int volume;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
        
    }
    
    public void PrintSomeThing(string thing)
    {
        print(thing);
    }
}
