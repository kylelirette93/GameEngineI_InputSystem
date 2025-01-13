using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint; // A transform where the bullet should spawn (usually the gun or player position)
    private float bulletSpeed;
    private GameObject currentBullet;
    bool isCharging = false;

    private void OnEnable()
    {
        Actions.onShootStarted += InstantiateBullet;
        Actions.onShootPerformed += ChargeShot;
        Actions.onShootCanceled += FireShot;
    }

    private void OnDisable()
    {
        Actions.onShootStarted -= InstantiateBullet;
        Actions.onShootPerformed -= ChargeShot;
        Actions.onShootCanceled -= FireShot;
    }

    // Instantiate a new bullet at the player's position
    void InstantiateBullet()
    {
        bulletSpeed = 5f;
    }

    // Charge shot by gradually increasing speed
    void ChargeShot()
    {
        if (!isCharging)
        {
            isCharging = true;
            StartCoroutine(IncreaseShotSpeed());
        }

    }

    private IEnumerator IncreaseShotSpeed()
    {
        while (bulletSpeed < 200f)
        {
            bulletSpeed += 20f;
            yield return new WaitForSeconds(0.1f); // Adjust the speed increase rate
        }
    }


    void FireShot()
    {
        if (currentBullet == null)
        {
            GameObject currentBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        currentBullet.transform.position += currentBullet.transform.forward * bulletSpeed * Time.deltaTime;
        }
        bulletSpeed = 0f;
        isCharging = false;
    }
}