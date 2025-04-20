using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject buttonPrefab;


    public void helpButton()
    {
        buttonPrefab.SetActive(true);
    }
    public void startingButton()
    {
        buttonPrefab.SetActive(false);
    }
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("Stage_1");
    }
}
