using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public void Interact()
    {
        if (gameObject.tag == "interaction_test")
        {
            Debug.Log("bruh");
        }
    }

}
