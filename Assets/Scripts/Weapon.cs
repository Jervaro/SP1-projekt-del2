using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool canFire = true;
    [SerializeField] private float timeBeforeReset;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canFire == true)
        {
            Shoot();
        }

        if (canFire == false)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                canFire = true;
                timer = 0f;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        canFire = false;
    }
    
}
