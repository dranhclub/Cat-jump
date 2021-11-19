using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField]
    private Bridge[] bridges;

    private SoundController soundController;

    void Start()
    {
        soundController = GameObject.Find("Sound").GetComponent<SoundController>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        soundController.playHitBtnSfx();
        foreach(var bridge in bridges)
        {
            bridge.Activated = true;
        }
    }
}

