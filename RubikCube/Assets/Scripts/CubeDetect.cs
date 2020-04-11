using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("{1} entered {0}", gameObject.name, other.gameObject.name));
    }

    private void _OnTriggerExit(Collider other)
    {
        Debug.Log(string.Format("{1} left {0}", gameObject.name, other.gameObject.name));
    }

    private void _OnTriggerStay(Collider other)
    {
        Debug.Log(string.Format("{1} staying at {0}", gameObject.name, other.gameObject.name));
    }
}
