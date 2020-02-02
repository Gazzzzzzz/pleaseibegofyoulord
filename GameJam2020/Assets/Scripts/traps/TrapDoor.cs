using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private triggertrap Trigger;
    [SerializeField] private Transform DoorTrap;
    [SerializeField] private GameObject FireTrap;
    Vector3 m_DoorPos = new Vector3();
    private void Start()
    {
        m_DoorPos = DoorTrap.transform.position;
    }
    private void Update()
    {
        if (Trigger.m_IsActivated)
        {
            if(m_DoorPos.y < -2.1f)
            {
                m_DoorPos.y += 0.1f;
                DoorTrap.transform.position = m_DoorPos;
            }
            else
            {
                FireTrap.SetActive(true);
            }

        }

    }
}
