using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> scoreAreas = new List<GameObject>();
    private int[] counts;
    public TextMeshProUGUI totalScore;
    private int numberOfPucks;
    public GameObject puck;
    public bool isPlacingPuck;
    private GameObject currentPuck;
    public bool isPlaced;
    
    // Start is called before the first frame update
    void Start()
    {
        counts = new int[4];
        numberOfPucks = 30;
        isPlacingPuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfPucks > 0)
        {
            SpawnPuck();
        }
    }

    public void CalculateScore()
    {
        for(int i = 0; i < 4; i++)
        {
            counts[i] = scoreAreas[i].GetComponent<Counter>().count;
        }
        
        int minCount = counts.Min();

        for(int i = 0; i < 4; i++)
        {
            counts[i] = counts[i] - minCount;
        }

        int score = minCount * 20 + counts[0] + counts[1] * 2 + counts[2] * 3 + counts[3] * 4;

        totalScore.text = "Total score: " + score;
    }

    public void SpawnPuck()
    {
        //Preparing to place puck
        if (!isPlacingPuck)
        {
            currentPuck = Instantiate(puck, new Vector3(0.75f, 0.0061f, 0), Quaternion.Euler(0, -90, 0));
            isPlacingPuck = true;
            isPlaced = false;
        }

        //Choosing position of puck
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && !isPlaced)
        {
            currentPuck.transform.position = hit.point;
        }

        if (Input.GetMouseButtonUp(0) && !isPlaced && currentPuck.transform.position.y >= 0.00600006f)
        {
            isPlaced = true;
        }
        
        //Adjusting direction of puck
        if (Input.GetKeyDown(KeyCode.A) && isPlaced)
        {
            currentPuck.transform.rotation = Quaternion.Euler(currentPuck.transform.rotation.x, currentPuck.transform.rotation.y - 1, currentPuck.transform.rotation.z);
        }

        if (Input.GetKeyUp(KeyCode.D) && isPlaced)
        {
            currentPuck.transform.rotation = Quaternion.Euler(currentPuck.transform.rotation.x, currentPuck.transform.rotation.y + 1, currentPuck.transform.rotation.z);
        }

        //Adjusting speed of puck
        if (Input.GetKeyUp(KeyCode.W) && currentPuck.GetComponent<PuckStart>().speed < 0.05f && isPlaced)
        {
            currentPuck.GetComponent<PuckStart>().speed += 0.005f;
        }

        if (Input.GetKeyUp(KeyCode.W) && currentPuck.GetComponent<PuckStart>().speed > 0 && isPlaced)
        {
            currentPuck.GetComponent<PuckStart>().speed += 0.005f;
        }

        //Placing puck
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            currentPuck.GetComponent<PuckStart>().enabled = true;
            isPlacingPuck = false;
            numberOfPucks--;
        }
    }
}
