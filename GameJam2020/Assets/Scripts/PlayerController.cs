using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Certaines variables sont initialisée sa NULL pour enlever le warning puisque je les assigne dans l'inspecteur

    [SerializeField]
    private Rigidbody m_PlayerRB = null;
    [SerializeField]
    private float m_PlayerSpeed = 4f;
    [SerializeField]
    private float m_PlayerJumpForce = 300f;
    [SerializeField]
    private Camera m_PlayerCamera = null;
    [SerializeField]
    private bool m_ObjectHeld = false;

    private Vector3 m_PlayerVelocity = new Vector3();
    private Vector3 m_PlayerDirectionRay = new Vector3(300f, 150f, 0f);
    private float m_OriginalSpeed;

    private bool m_CanMove = false;
    private bool m_CanJump = false;
    private bool m_CanSprint = false;
    private bool m_CanMoveObject = false;
    private bool m_CanInteract = false;


    void Update()
    {
        PlayerMove();
        PlayerJump();
        PlayerSprint();
        ObjectMove();
        Interaction();
    }

    public void PlayerCanMove()
    {
        m_CanMove = true;
    }
    void PlayerMove()
    {

        if (m_CanMove)
        {
            m_PlayerVelocity.x = 0f;
            m_PlayerVelocity.z = 0f;
            m_PlayerVelocity.y = 0f;

            if (Input.GetKey(KeyCode.W)) //Mouvement d'avant/arrière
            {
                m_PlayerVelocity += transform.forward;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                m_PlayerVelocity += -transform.forward;
            }


            if (Input.GetKey(KeyCode.D)) //Mouvement de cotés
            {
                m_PlayerVelocity += transform.right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                m_PlayerVelocity += -transform.right;
            }


            m_PlayerVelocity.Normalize(); //Normalisation de la vélocité pour éviter que le joueur avance plus vite à la diagonale
            m_PlayerVelocity *= m_PlayerSpeed;
            m_PlayerVelocity.y = m_PlayerRB.velocity.y;
            m_PlayerRB.velocity = m_PlayerVelocity;

        }


    }
    public void PlayerCanJump()
    {
        m_CanJump = true;
    }

    void PlayerJump()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space) && m_CanJump && Physics.Raycast(transform.position, new Vector3(0f, -1f, 0f), out hit, 0.52f, LayerMask.GetMask("Floor"))) //Raycast vers le bas qui permet au joueur de sauter uniquement lorsqu'il détecte le sol
        {
            
            m_PlayerRB.AddForce(0f, m_PlayerJumpForce, 0f);
            
        }


    }
    public void PlayerCanSprint()
    {
        m_CanSprint = true;
    }

    void PlayerSprint()
    {

        m_OriginalSpeed = 4f;
        if (Input.GetKey(KeyCode.LeftShift) && m_CanSprint)
        {
            
            m_PlayerSpeed = 7f;
        }
        else
        {
            m_PlayerSpeed = m_OriginalSpeed;
        }
    }
    public void PlayerCanMoveObject()
    {
        m_CanMoveObject = true;
    }

    private void ObjectMove()
    {
        if (m_CanMoveObject)
        {

            RaycastHit hit;
            Ray ray = m_PlayerCamera.ScreenPointToRay(m_PlayerDirectionRay);
            if (Physics.Raycast(ray, out hit, 2f, LayerMask.GetMask("MovableObject")) && m_ObjectHeld && Input.GetKeyDown(KeyCode.F))
            {
                hit.collider.transform.parent = null;
                hit.collider.attachedRigidbody.constraints = RigidbodyConstraints.None;
                m_ObjectHeld = false;
            }
            else if (Physics.Raycast(ray, out hit, 2f, LayerMask.GetMask("MovableObject")) && !m_ObjectHeld && Input.GetKeyDown(KeyCode.F))
            {
                m_ObjectHeld = true;
                hit.collider.gameObject.transform.parent = gameObject.transform;
                hit.collider.attachedRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    public void PlayerCanInteract()
    {
        m_CanInteract = true;
    }
    private void Interaction()
    {
        if (m_CanInteract)
        {
            RaycastHit hit;
            Ray ray = m_PlayerCamera.ScreenPointToRay(m_PlayerDirectionRay);
            if (Physics.Raycast(ray, out hit, 2f, LayerMask.GetMask("Interaction")) && Input.GetKeyDown(KeyCode.E))
            {
                InteractionManager m_InteractionManager = hit.collider.gameObject.GetComponent<InteractionManager>();

                m_InteractionManager.Interact();
            }
        }
    }
}
