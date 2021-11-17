using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Singleton
    private static SceneController instance;
    private static int level;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static void NextScene()
    {
        SceneManager.LoadScene(++level);
        Debug.Log("Loaded level " + level);
    }

    static public int Level
    {
        get;
    }
}
