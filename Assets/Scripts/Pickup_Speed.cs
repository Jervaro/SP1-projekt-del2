using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{
    [SerializeField] private float multiplySpeedBy = 1.5f;
    [SerializeField] private float timeBeforeReset;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerMovement playerMovement;

    private bool isUsingMovementSpeed = false;
    private float timer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingMovementSpeed == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                playerMovement.ResetMovementSpeed();
                timer = 0f;
                isUsingMovementSpeed = false;
                spriteRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsingMovementSpeed == false)
        {
            if (collision.CompareTag("Player") == true)
            {
                if (playerMovement == null)
                {
                    playerMovement = collision.GetComponent<PlayerMovement>();
                }
                isUsingMovementSpeed = true;
                playerMovement.SetNewMovementSpeed(multiplySpeedBy);
                audioSource.PlayOneShot(audioClip);
                spriteRenderer.enabled = false;
            }
        }
    }
}
