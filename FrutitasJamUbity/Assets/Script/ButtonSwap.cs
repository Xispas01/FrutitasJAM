using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSwap : MonoBehaviour
{
    public TextMeshProUGUI UpP, LeftP, RightP, DownP, AttackP;
    private GameObject currentKey;


    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);


    // Use this for initialization
    void Start () {
        if (SettingsSaving.isFirstRun){
            SettingsSaving.keys.Add("Up", KeyCode.W);
            SettingsSaving.keys.Add("Left", KeyCode.A);
            SettingsSaving.keys.Add("Right", KeyCode.D);
            SettingsSaving.keys.Add("Down", KeyCode.S);
            SettingsSaving.keys.Add("Attack", KeyCode.K);
        }

        UpP.text = SettingsSaving.keys["Up"].ToString();
        DownP.text = SettingsSaving.keys["Down"].ToString();
        LeftP.text = SettingsSaving.keys["Left"].ToString();
        RightP.text = SettingsSaving.keys["Right"].ToString();
        AttackP.text = SettingsSaving.keys["Attack"].ToString();

    }
    
    
    public void defaultButton()
    {
        SettingsSaving.keys.Add("Up", KeyCode.W);
        SettingsSaving.keys.Add("Left", KeyCode.A);
        SettingsSaving.keys.Add("Right", KeyCode.D);
        SettingsSaving.keys.Add("Down", KeyCode.S);
        SettingsSaving.keys.Add("Attack", KeyCode.K);


        UpP.text = SettingsSaving.keys["Up"].ToString();
        DownP.text = SettingsSaving.keys["Down"].ToString();
        LeftP.text = SettingsSaving.keys["Left"].ToString();
        RightP.text = SettingsSaving.keys["Right"].ToString();
        AttackP.text = SettingsSaving.keys["Attack"].ToString();
    }

    void OnGUI(){
        if(currentKey != null){
            Event e = Event.current;
            if(e.isKey){
                bool used = false;
                foreach (var k in SettingsSaving.keys.Values){//Revision repeticion de input
                    if(k == e.keyCode){
                        used = true;
                    }
                }
                if (used == false){//Sistema anti repeticion de input
                    SettingsSaving.keys[currentKey.name] = e.keyCode;
                    currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                    currentKey.GetComponent<Image>().color = normal;
                    currentKey = null;
                }else{
                    SettingsSaving.keys[currentKey.name] = SettingsSaving.keys[currentKey.name];
                    currentKey.GetComponent<Image>().color = normal;
                    currentKey = null;
                }
            }
        }
    }

    public void ChangeKey(GameObject clicked){
        if(currentKey != null){
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
}