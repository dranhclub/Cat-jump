using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField]
    private Bridge bridge;

    private void OnTriggerEnter(Collider other)
    {
        bridge.Activated = true;
    }
}

