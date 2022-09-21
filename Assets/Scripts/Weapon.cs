using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform MuzzleFlashPrefab;

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
        // Creates the bullets and SFX
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        canFire = false;
        audioSource.PlayOneShot(audioClip);

        // Creates muzzle flash
        Transform clone = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.7f);
        clone.localScale = new Vector3(size, size, 1);
        Destroy(clone.gameObject, 0.05f);
    }
    
}
