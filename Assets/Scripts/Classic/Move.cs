using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    private Transform m_Transform;

    void Start()
    {
        m_Transform = this.transform;
    }
    // Update is called once per frame
    void Update()
    {
        m_Transform.Translate(0,0,0.1f);

        if(m_Transform.position.z > 28) 
            m_Transform.position = new Vector3(Random.Range(-48,48), m_Transform.position.y, -28); 
    }
}
