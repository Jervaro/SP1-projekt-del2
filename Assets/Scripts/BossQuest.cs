using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossQuest : MonoBehaviour
{
    [SerializeField] private GameObject questGiverText;
    [SerializeField] private Text textComponent;
    [SerializeField] private string questBeginText;
    [SerializeField] private string questCompleteText;
    [SerializeField] private GameObject doorToOpenQuestComplete;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(true);

        textComponent.text = questBeginText;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss") == null)
        {
            textComponent.text = questCompleteText;
            player.GetComponent<Quest_Player>().isQuestComplete = true;
            doorToOpenQuestComplete.SetActive(false);
        }
        else textComponent.text = questBeginText;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (GameObject.Find("Boss") == null)
            {
                textComponent.text = questCompleteText;
                collision.GetComponent<Quest_Player>().isQuestComplete = true;
                doorToOpenQuestComplete.SetActive(false);
            }
            else textComponent.text = questBeginText;

           // questGiverText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            //questGiverText.SetActive(false);
        }
    }

}
