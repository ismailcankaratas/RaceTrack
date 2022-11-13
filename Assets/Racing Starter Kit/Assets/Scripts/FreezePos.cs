using UnityEngine;

public class FreezePos : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    void Update()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}
