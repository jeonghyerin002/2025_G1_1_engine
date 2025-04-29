using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBorard : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI stage_1;
    public TextMeshProUGUI stage_2;
    public TextMeshProUGUI stage_3;
    public TextMeshProUGUI stage_4;
    public TextMeshProUGUI stage_5;
    void Start()
    {
        stage_1.text = "STAGE 1 : " + HighScore.Load(1).ToString();
        stage_2.text = "STAGE 2 : " + HighScore.Load(2).ToString();
        stage_3.text = "STAGE 3 : " + HighScore.Load(3).ToString();
        stage_4.text = "STAGE 4 : " + HighScore.Load(4).ToString();
        stage_5.text = "STAGE 5 : " + HighScore.Load(5).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
