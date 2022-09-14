using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] private float timeBeforeReset;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;

    private bool canFire = true;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
        if (Input.GetButtonDown("Fire1") && canFire == true)
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
        audioSource.PlayOneShot(audioClip);
    }
    
}
