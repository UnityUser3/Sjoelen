using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int count;

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            counterText.text = "Pucks with " + gameObject.tag.ToLower() + ": " + count;
            
            other.gameObject.GetComponent<MeshCollider>().isTrigger = false;
        }
    }
}
