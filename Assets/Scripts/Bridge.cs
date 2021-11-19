using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private bool activated;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material inactiveMaterial;

    private void Start()
    {
        Activated = false;
    }

    public bool Activated
    {
        get { return activated; }
        set
        {
            activated = value;
            if (activated == true)
            {
                GetComponent<MeshRenderer>().material = activeMaterial;
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<MeshRenderer>().material = inactiveMaterial;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
