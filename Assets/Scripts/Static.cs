using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{
    public static int lives = 3;
    public static int level = 1;
    public static bool gamepause = false;
    public static bool musicOn = true;
    public static bool soundOn = true;

    private static Static instance;
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
}
