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
    public GameManager gameManager;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            counterText.text = "Pucks with " + gameObject.tag.ToLower() + ": " + count;
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}
