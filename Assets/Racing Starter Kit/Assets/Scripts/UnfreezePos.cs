using UnityEngine;

public class UnfreezePos : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    void Update()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.None;
    }
}
