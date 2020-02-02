using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    private bool m_ContinueText = false;
    private bool m_EndText = false;
    [SerializeField]
    private GameObject m_TextBackground;
    [SerializeField]
    private GameObject m_Text1;
    [SerializeField]
    private GameObject m_Text2;
    [SerializeField]
    private GameObject m_Text3;
    [SerializeField]
    private GameObject m_FeatureListGiven;
    [SerializeField]
    private GameObject m_HelpBackground;
    [SerializeField]
    private GameObject m_HelpTextTab;
    private void Start()
    {
        m_TextBackground.SetActive(true);
        m_Text1.SetActive(true);
    }
    void Update()
    {
        FirstConversation();
    }

    private void FirstConversation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && m_EndText)
        {
            m_Text3.SetActive(false);
            m_TextBackground.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && m_ContinueText)
        {
            m_Text2.SetActive(false);
            m_Text3.SetActive(true);
            m_HelpBackground.SetActive(false);
            m_HelpTextTab.SetActive(false);
            m_EndText = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_Text1.SetActive(false);
            m_Text2.SetActive(true);
            m_FeatureListGiven.SetActive(true);
            m_HelpBackground.SetActive(true);
            m_HelpTextTab.SetActive(true);
            m_ContinueText = true;
        }
    }
}
