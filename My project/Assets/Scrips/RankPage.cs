using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] GameObject rowPrefab;

    StageResultList allData;

    int stageIndex = 1;


    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList(1);
    }

     public void RefreshRankList(int index)
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }

        var sortedDate = allData.results.Where(r => r.stage == index).OrderByDescending(x => x.score).ToList();

        for (int i = 0; i < sortedDate.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedDate[i].playerName} - {sortedDate[i].score}";
        }

    }

}