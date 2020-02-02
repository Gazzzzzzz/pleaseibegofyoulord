using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggertrap : MonoBehaviour
{

    public bool m_IsActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        m_IsActivated = true;
    }
    private void OnTriggerExit(Collider other)
    {
        m_IsActivated = false;
    }
}
