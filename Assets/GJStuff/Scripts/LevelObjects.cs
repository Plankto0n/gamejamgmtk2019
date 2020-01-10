using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObjects : MonoBehaviour
{
    public GameObject PropsGrasStd;
    public GameObject PropsGrasUpDown;
    public GameObject PropsStonesStd;
    public GameObject PropsStoneUpDown;
    public GameObject PropsFlowersStd;
    public GameObject PropsFlowersUpDown;
    public GameObject PropsSaplingsStd;
    public GameObject PropsSaplingsUpDown;

    public GameObject LightGreyStd;
    public GameObject LightGreyUpDown;
    public GameObject LightOrangeStd;
    public GameObject LightOrangeUpDown;
    public GameObject LightBlueStd;
    public GameObject LightBlueUpDown;
    public GameObject LightYellowStd;
    public GameObject LightYellowUpDown;
    public GameObject LightGreenStd;
    public GameObject LightGreenUpDown;
    
    public GameObject ArtefaktOrange;
    public GameObject ArtefaktBlue;
    public GameObject ArtefaktYellow;
    public GameObject ArtefaktGreen;

    public Button ViewOrange;
    public Button ViewBlue;
    public Button ViewYellow;
    public Button ViewGreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PropsGrasStd.SetActive(false);
        PropsGrasUpDown.SetActive(false);
        PropsStonesStd.SetActive(false);
        PropsStoneUpDown.SetActive(false);
        PropsFlowersStd.SetActive(false);
        PropsFlowersUpDown.SetActive(false);
        PropsSaplingsStd.SetActive(false);
        PropsSaplingsUpDown.SetActive(false);
        
        SetLight(GameManager.GameProgress.Grey, true);
        SetLight(GameManager.GameProgress.Orange, false);
        SetLight(GameManager.GameProgress.Blue, false);
        SetLight(GameManager.GameProgress.Yellow, false);
        SetLight(GameManager.GameProgress.Green, false);
        
        ArtefaktOrange.SetActive(true);
        ArtefaktBlue.SetActive(false);
        ArtefaktYellow.SetActive(false);
        ArtefaktGreen.SetActive(false);

        ViewOrange.interactable = false;
        ViewBlue.interactable = false;
        ViewYellow.interactable = false;
        ViewGreen.interactable = false;
    }

    public void SetLight(GameManager.GameProgress color, bool status)
    {
        switch (color)
        {
             case GameManager.GameProgress.Grey:
                 Light[] lightsStd = LightGreyStd.GetComponentsInChildren<Light>();
                 foreach (Light light in lightsStd)
                 {
                     light.enabled = status;
                 }
                 Light[] lightsUpD = LightGreyUpDown.GetComponentsInChildren<Light>();
                 foreach (Light light in lightsUpD)
                 {
                     light.enabled = status;
                 }
                 return;
            case GameManager.GameProgress.Orange:
                Light[] lightsOrangeStd = LightOrangeStd.GetComponentsInChildren<Light>();
                foreach (Light light in lightsOrangeStd)
                {
                    light.enabled = status;
                }
                Light[] lightsOrangeUpD = LightOrangeUpDown.GetComponentsInChildren<Light>();
                foreach (Light light in lightsOrangeUpD)
                {
                    light.enabled = status;
                }
                return;
            case GameManager.GameProgress.Blue:
                Light[] lightsBlueStd = LightBlueStd.GetComponentsInChildren<Light>();
                foreach (Light light in lightsBlueStd)
                {
                    light.enabled = status;
                }
                Light[] lightsBlueUpD = LightBlueUpDown.GetComponentsInChildren<Light>();
                foreach (Light light in lightsBlueUpD)
                {
                    light.enabled = status;
                }
                return;
            case GameManager.GameProgress.Yellow:
                Light[] lightsYellowStd = LightYellowStd.GetComponentsInChildren<Light>();
                foreach (Light light in lightsYellowStd)
                {
                    light.enabled = status;
                }
                Light[] lightsYellowUpD = LightYellowUpDown.GetComponentsInChildren<Light>();
                foreach (Light light in lightsYellowUpD)
                {
                    light.enabled = status;
                }
                return;
            case GameManager.GameProgress.Green:
                Light[] lightsGreenStd = LightGreenStd.GetComponentsInChildren<Light>();
                foreach (Light light in lightsGreenStd)
                {
                    light.enabled = status;
                }
                Light[] lightsGreenUpD = LightGreenUpDown.GetComponentsInChildren<Light>();
                foreach (Light light in lightsGreenUpD)
                {
                    light.enabled = status;
                }
                return;
        }
    }
}
