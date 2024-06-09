using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public bool IsPlayerBullet;

    [SerializeField]
    private float m_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerBullet)
        {
            transform.position += Vector3.right * Time.deltaTime * m_speed;
        }
    }
}
