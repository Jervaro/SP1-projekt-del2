using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float timeBeforeDeletion = 1f;
    private bool canPickupCoin = true;

    private bool removeGameObject = false;
    //private float timer = 0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            
            if(canPickupCoin == true)
            {
                collision.GetComponent<PlayerState>().CoinPickup();
                spriteRenderer.enabled = false;
                particles.Play();
                removeGameObject = true;
                canPickupCoin = false;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(pickupClip);
                Invoke("DestroyCoin", timeBeforeDeletion);
            }
        }
    }

    void DestroyCoin()
    {
        Destroy(coinPrefab);
    }

}
