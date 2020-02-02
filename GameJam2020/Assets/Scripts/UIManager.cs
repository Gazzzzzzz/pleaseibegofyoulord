using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_FeatureList;
    [SerializeField]
    private GameObject m_ControlMenu;

    Vector3 m_FeatureListPosition = new Vector3(1158f, 407f, 0f);
    Vector3 m_FeatureListStartingPosition = new Vector3();

    private bool m_MenuOpen = false;
    private void Start()
    {
        m_FeatureListStartingPosition = m_FeatureList.anchoredPosition;
    }
    void Update()
    {
        MoveFeatureList();
        OpenControls();
    }

    private void MoveFeatureList()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            m_FeatureList.anchoredPosition = m_FeatureListPosition;
        }
        else
        {
            m_FeatureList.anchoredPosition = m_FeatureListStartingPosition;
        }
    }

    private void OpenControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_MenuOpen == false)
        {
            m_ControlMenu.SetActive(true);
            m_MenuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && m_MenuOpen)
        {
            m_ControlMenu.SetActive(false);
            m_MenuOpen = false;
        }
    }
}
