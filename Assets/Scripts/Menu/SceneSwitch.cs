using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }

    public void OnPlayButtonClick()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
