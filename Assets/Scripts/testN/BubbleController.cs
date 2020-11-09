using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Material m_material;
    private GameObject m_playerPosition;
    private Vector3 m_oldPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_material = GetComponent<Renderer>().material;
        m_playerPosition = GameObject.FindGameObjectWithTag("Bubble");
        SetPlayerPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerPosition.transform.position != m_oldPlayerPosition)
        {
            SetPlayerPosition();
        }
    }
    void SetPlayerPosition()
    {
        if (m_playerPosition != null)
        {
            m_material.SetVector("_PlayerPos", m_playerPosition.transform.position);
            m_oldPlayerPosition = m_playerPosition.transform.position;
        }
    }

}
