using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationData
{
    public int Temperature { get; set; }
    public int Humidity { get; set; }
    public bool Led { get; set; }
    public bool Pump { get; set; }

    public StationData(int temperature = 0, int humidity = 0, bool led = false, bool pump = false)
    {
        Temperature = temperature;
        Humidity = humidity;
        Led = led;
        Pump = pump;
    }
}

public class DashboardManager : MonoBehaviour
{
    private StationData stationData;

    [Header("User Interface")]
    public Text temperatureValue;
    public Text humidityValue;
    public int temperatureReceivedValue;
    public int humidityReceivedValue;

    public Toggle ledToggle;
    public Toggle pumpToggle;
    public Image ledToggleBackground;
    public Image pumpToggleBackground;
    public Sprite inActiveToggleSprite;
    public Sprite activeToggleSprite;

    // Start is called before the first frame update
    void Start()
    {
        stationData = new StationData();
        temperatureValue.text = $"{ temperatureReceivedValue }°C";
        humidityValue.text = $"{ humidityReceivedValue }%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleLedToggleClick()
    {
        stationData.Led = ledToggle.isOn;
        ledToggleBackground.sprite = ledToggle.isOn ? activeToggleSprite : inActiveToggleSprite;
    }

    public void HandlePumpToggleClick()
    {
        stationData.Pump = pumpToggle.isOn;
        pumpToggleBackground.sprite = pumpToggle.isOn ? activeToggleSprite : inActiveToggleSprite;
    }
}
