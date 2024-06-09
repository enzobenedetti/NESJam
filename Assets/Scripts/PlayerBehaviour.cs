using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private float m_speed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Vector2 movement = Vector2.zero;
            if (Input.GetButton("Horizontal"))
            {
                movement += Vector2.right * Input.GetAxisRaw("Horizontal") * m_speed;
            }
            if (Input.GetButton("Vertical"))
            {
                movement += Vector2.up * Input.GetAxisRaw("Vertical") * m_speed;
            }

            m_rigidbody.velocity = movement;
        }
        else
        {
            m_rigidbody.velocity = Vector2.zero;
        }
        if (Input.GetButtonDown("Fire"))
        {

        }
    }
}
