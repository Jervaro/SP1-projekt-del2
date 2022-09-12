using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int healthPoints = 2;
    public int initialHealthPoints;
    public int coinAmount = 0;

    private GameObject respawnPosition;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition = true;


    // Start is called before the first frame update
    void Start()
    {
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        healthPoints = initialHealthPoints;
        if(useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }
        respawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }


    public void DoHarm(int doHarmByThisMuch)
    {
        healthPoints -= doHarmByThisMuch;
        if(healthPoints <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
    }

    public void CoinPickup()
    {
        coinAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }
}
