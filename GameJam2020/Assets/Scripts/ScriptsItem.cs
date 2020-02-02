using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsItem : MonoBehaviour
{
    Vector3 m_SpawnPoint = new Vector3(3f, 0.5f, 2.5f);
    [SerializeField]
    private GameObject m_ControlWMovement;
    [SerializeField]
    private GameObject m_ControlSMovement;
    [SerializeField]
    private GameObject m_ControlAMovement;
    [SerializeField]
    private GameObject m_ControlDMovement;
    [SerializeField]
    private GameObject m_LineMovement;
    [SerializeField]
    private GameObject m_LineHP;
    [SerializeField]
    private GameObject m_LineSprint;
    [SerializeField]
    private GameObject m_LineInteraction;
    [SerializeField]
    private GameObject m_LineJump;
    [SerializeField]
    private GameObject m_LineWallGrab;
    [SerializeField]
    private GameObject m_LineSpawn;
    [SerializeField]
    private GameObject m_ControlSprint;
    [SerializeField]
    private GameObject m_ControlInteraction;
    [SerializeField]
    private GameObject m_ControlWallGrab;
    [SerializeField]
    private GameObject m_ControlJump;
    [SerializeField]
    private GameObject m_ControlReload;
    [SerializeField]
    private GameObject m_ControlSpawn;
    [SerializeField]
    private GameObject m_HPBar;
    [SerializeField]
    private GameObject m_ScriptPrint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Movement" )
        {
            m_ControlWMovement.SetActive(true);
            m_ControlSMovement.SetActive(true);
            m_ControlAMovement.SetActive(true);
            m_ControlDMovement.SetActive(true);
            m_LineMovement.SetActive(true);
        }
        else if (other.tag == "HP")
        {
            m_LineHP.SetActive(true);
            m_HPBar.SetActive(true);
            transform.position = m_SpawnPoint;
            m_ScriptPrint.SetActive(true);

        }
        else if (other.tag == "Sprint")
        {
            m_LineSprint.SetActive(true);
            m_ControlSprint.SetActive(true);
        }
        else if (other.tag == "Interaction")
        {
            m_LineInteraction.SetActive(true);
            m_ControlInteraction.SetActive(true);
        }
        else if (other.tag == "Jump")
        {
            m_LineJump.SetActive(true);
            m_ControlJump.SetActive(true);
        }
        else if (other.tag == "WallGrab")
        {
            m_LineWallGrab.SetActive(true);
            m_ControlWallGrab.SetActive(true);
        }
        else if (other.tag == "Spawn")
        {
            m_LineSpawn.SetActive(true);
            m_ControlSpawn.SetActive(true);
        }
        else if (other.tag == "Checkpoint")
        {
            m_ControlReload.SetActive(true);
        }
        else if (other.tag == "Checkpoint")
        {
            m_ControlReload.SetActive(true);
        }
    }
}
