using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSaving : MonoBehaviour
{
    public static SettingsSaving instance;

    public static bool isFirstRun = true;

    public static List<int> widthList = new List<int>();
    public static List<int> heightList = new List<int>();
    public static List<int> refreshList = new List<int>();

    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    
    public static float musicV = 1;
    public static float sfxV = 1;
    
    public static int i = 0;

    public static int width;
    public static int height;
    public static bool fullscreen = true;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else if(instance != null){
            Destroy(transform.parent.gameObject);
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    private void Update() {
        isFirstRun = false;
    }
}

