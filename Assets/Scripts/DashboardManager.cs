using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationData
{
    public string ProjectId { get; set; }
}

public class DashboardManager : MonoBehaviour
{
    [Header("User Interface")]
    public Text temperatureValue;
    public Text humidityValue;
    public int temperatureReceivedValue = 69;
    public int humidityReceivedValue = 90;

    public Toggle ledToggle;
    public Toggle pumpToggle;
    public Image ledToggleBackground;
    public Image pumpToggleBackground;
    public Sprite inActiveToggleSprite;
    public Sprite activeToggleSprite;

    // Start is called before the first frame update
    void Start()
    {
        temperatureValue.text = $"{ temperatureReceivedValue }°C";
        humidityValue.text = $"{ humidityReceivedValue }%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleLedToggleClick()
    {
        ledToggleBackground.sprite = ledToggle.isOn ? activeToggleSprite : inActiveToggleSprite;
    }

    public void HandlePumpToggleClick()
    {
        pumpToggleBackground.sprite = pumpToggle.isOn ? activeToggleSprite : inActiveToggleSprite;
    }
}
