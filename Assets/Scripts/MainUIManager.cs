using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUIManager : MonoBehaviour
{
   

    public void Start()
    {
       
    }
    public void StartNew()
    {
        
        SceneManager.LoadScene(1);
        
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void NameEntered(string name)
    {
        Data.Instance.NameSelect = name;
    }

}
