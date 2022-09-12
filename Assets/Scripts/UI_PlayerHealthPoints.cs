using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHealthPoints : MonoBehaviour
{
    public PlayerState playerState;

    private Slider slider;

    int maxPlayerHealthPoints;

    // Start is called before the first frame update
    void Start()
    {
        maxPlayerHealthPoints = playerState.initialHealthPoints;
        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.maxValue = maxPlayerHealthPoints;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerState.healthPoints;
        
    }
}
