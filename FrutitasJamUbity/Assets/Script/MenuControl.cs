using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public static void zSceneChange(int i){
        SceneManager.LoadScene(i);
    }
    public static void zSceneChange(string s){
        SceneManager.LoadScene(s);
    }

    public static void zScreenChange(GameObject target){
        target.SetActive(!target.activeSelf);
    }

    public static void zEndGame(){
        Application.Quit();
        Debug.Log("Adios!");
    }
}
