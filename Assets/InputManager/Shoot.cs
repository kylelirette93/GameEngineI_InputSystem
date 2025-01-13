using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint; // Point where bullet should spawn.
    private float bulletSpeed;
    private GameObject currentBullet; // Reference to the current bullet.
    bool isCharging = false;
    public TextMeshProUGUI chargeText;

    private void OnEnable()
    {
        // Subscribe to shooting input events.
        Actions.onShootStarted += StartCharging;
        Actions.onShootPerformed += ChargeShot;
        Actions.onShootCanceled += FireShot;
    }

    private void OnDisable()
    {
        // Unsubscribe from shooting input events. 
        Actions.onShootStarted -= StartCharging;
        Actions.onShootPerformed -= ChargeShot;
        Actions.onShootCanceled -= FireShot;
    }

    void StartCharging()
    {
        Debug.Log("Shoot button pressed.");
        chargeText.gameObject.SetActive(true);
        bulletSpeed = 1f;
        isCharging = true;
        chargeText.text = "Charging: " + bulletSpeed + "%";
    }

    void ChargeShot()
    {
        Debug.Log("Shoot button is being held.");
        if (isCharging)
        {
            // Start charging.
            StartCoroutine(IncreaseShotSpeed());
        }       
    }

    private IEnumerator IncreaseShotSpeed()
    {
        while (isCharging && bulletSpeed < 100f)
        {
            // Gradually increase the bullet speed, capped at 100.
            bulletSpeed += 1f;
            chargeText.text = "Charging: " + bulletSpeed + "%";
            yield return new WaitForSeconds(0.02f); 
        }
    }


    void FireShot()
    {
        Debug.Log("Shoot button released.");

        if (currentBullet == null)
        {
            // Instantiate a bullet from the gun.
            currentBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
        // Fire the bullet, reset the speed and stop charging.
        currentBullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * bulletSpeed;
        bulletSpeed = 0f;
        isCharging = false;
        chargeText.text = "Charging: " + bulletSpeed + "%";

        chargeText.gameObject.SetActive(false);
    }
}