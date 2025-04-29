using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{
    private const string KEY = "HighScore";

    public static int Load(int stage)
    {
        return PlayerPrefs.GetInt(KEY + "_" + stage, 0);
    }


    public static void TrySet(int stage, int newScore)
    {
        if (newScore <= Load(stage))
            return;

        PlayerPrefs.SetInt(KEY + "_" + stage, newScore);
        PlayerPrefs.Save();
    }
}











//public class ScoreTest : MonoBehaviour
//{
    // Start is called before the first frame update
 //   void Start()
 //   {
       //PlayerPrefs.SetInt("SCORE", 999);
        //PlayerPrefs.Save();
        //int best = PlayerPrefs.GetInt("SCORE");
        
 //  }

    // Update is called once per frame
 //   void Update()
 //   {
        
  //  }
//}
