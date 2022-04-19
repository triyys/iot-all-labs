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
    public Toggle ledToggle;
    public Toggle pumpToggle;
    public Image ledToggleBackground;
    public Image pumpToggleBackground;
    public Sprite inActiveToggleSprite;
    public Sprite activeToggleSprite;

    // Start is called before the first frame update
    void Start()
    {
        //HandleLedToggleClick();
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
