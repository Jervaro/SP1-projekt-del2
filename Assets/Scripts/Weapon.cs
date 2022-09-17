using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Animator animator;

    [SerializeField] private float timeBeforeReset;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;

    private bool canFire = true;
    private float timer = 0f;
    private bool isShooting = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsShooting", isShooting);

        audioSource.volume = volume;
        if (Input.GetButtonDown("Fire1") && canFire == true)
        {
            Shoot();
            isShooting = true;
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
