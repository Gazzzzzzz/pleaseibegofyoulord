using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_MainMenu;
    [SerializeField]
    private GameObject m_MainGame;
    [SerializeField]
    private Button m_ButtonStart;
    [SerializeField]
    private Button m_ButtonQuit;

    void Update()
    {
        m_ButtonStart.onClick.AddListener(MainGame);
        m_ButtonQuit.onClick.AddListener(QuitGame);
    }

    private void MainGame()
    {
        m_MainMenu.SetActive(false);
        m_MainGame.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
