using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCount : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private void Start()
    {
        goldText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {   
        goldText.text = GameManager.Instance.totalGold.ToString();
    }
}
