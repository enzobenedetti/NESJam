using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    [SerializeField]
    private float m_speed = 0.7f;
    [SerializeField]
    private float m_deadZone = 0.1f;

    [SerializeField]
    private GameObject m_bullet;
    private float m_timeSinceLastBullet = 500f;
    [SerializeField]
    private float m_bulletCooldown = 0.2f;
    private bool m_isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timeSinceLastBullet += Time.deltaTime;

        if (m_isFiring && m_timeSinceLastBullet >= m_bulletCooldown)
        {
            GameObject newBullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletBehaviour>().IsPlayerBullet = true;

            m_timeSinceLastBullet = 0f;
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 movement = Vector2.zero;
        Vector2 input = value.Get<Vector2>();

        if (input.x > m_deadZone)
        {
            movement += Vector2.right * m_speed;
        }
        else if (input.x < -m_deadZone)
        {
            movement += Vector2.left * m_speed;
        }
        if (input.y > m_deadZone)
        {
            movement += Vector2.up * m_speed;
        }
        else if (input.y < -m_deadZone)
        {
            movement += Vector2.down * m_speed;
        }

        m_rigidbody.velocity = movement;
    }

    void OnFire()
    {
        m_isFiring = !m_isFiring;
    }
}
