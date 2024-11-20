using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> scoreAreas = new List<GameObject>();
    public int[] counts = new int[4];
    public TextMeshProUGUI totalScore;
    private int numberOfPucks = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateScore();
        
        if (numberOfPucks <= 0)
        {
            EndGame();
        }
    }

    public void CalculateScore()
    {
        for(int i = 0; i < 4; i++)
        {
            counts[i] = scoreAreas[i].GetComponent<Counter>().count;
        }
        
        minCount = counts.Min();

        for(int i = 0; i < 4; i++)
        {
            counts[i] = counts[i] - minCount;
        }

        int score = minCount * 20 + counts[0] + counts[1] * 2 + counts[2] * 3 + counts[3] * 4;

        totalScore.text = "Total score: " + score;
    }

    public void EndGame()
    {

    }
}
