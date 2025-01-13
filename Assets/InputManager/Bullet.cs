using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 5f;

    private void Start()
    {
        Invoke("DestroyBullet", 0.5f);
    }

    private void Update()
    {
        transform.position += new Vector3(-bulletSpeed * Time.deltaTime, 0, 0);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
