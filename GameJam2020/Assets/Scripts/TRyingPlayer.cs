using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TRyingPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Spawnable;
    Vector3 m_SpawnPoint = new Vector3();
    private int m_SpawnCount = 0;
    public Rigidbody player;
    private int movespeed = 5;
    Vector3 direction = new Vector3();
    public int HP = 3;
    Vector2 m_HealthBarSizeMedium = new Vector2(600f, 30f);
    Vector2 m_HealthBarSizeSmall = new Vector2(200f, 30f);
    Vector2 m_HealthBarSIzeBig = new Vector2(1000f, 30f);
    [SerializeField]
    private RectTransform m_HealthBarState;
    [SerializeField]
    private GameObject m_HealthBar;
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction -= transform.forward;
        }
        else
        {
            direction = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction -= transform.right;
        }

        direction.Normalize();
        player.velocity = direction;
        player.velocity *= movespeed;
        m_SpawnPoint.x = transform.position.x;
        m_SpawnPoint.y = transform.position.y;
        m_SpawnPoint.z = transform.position.z + 3f;
        HPManagement();
        Spawn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ennemy")
        {
            HP -= 1;
        }
    }
    private void HPManagement()
    {
        if (HP == 2)
        {
            m_HealthBarState.sizeDelta = m_HealthBarSizeMedium;
            m_HealthBar.GetComponent<Image>().color = Color.yellow;
        }
        else if (HP == 1)
        {
            m_HealthBarState.sizeDelta = m_HealthBarSizeSmall;
            m_HealthBar.GetComponent<Image>().color = Color.red;

        }
        else if (HP == 0)
        {
            m_HealthBarState.sizeDelta = Vector2.zero;
            SceneManager.LoadScene("TestManager");
        }
        else
        {
            m_HealthBarState.sizeDelta = m_HealthBarSIzeBig;
        }
    }

    private void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_SpawnCount < 1)
        {
            Instantiate(m_Spawnable, m_SpawnPoint, Quaternion.identity);
            m_SpawnCount += 1;
        }
    }
}
