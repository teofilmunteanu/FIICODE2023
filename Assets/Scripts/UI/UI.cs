using UnityEngine;

public class UI : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            m_Animator.SetTrigger("Open");
        }
    }
}
