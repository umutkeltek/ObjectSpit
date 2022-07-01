using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    private Slider _slider;
    private float newDistance;
    private float progressValue;
    [SerializeField] private Transform player;
    [SerializeField] private Transform endLine;
    private float playerX;
    private float endLineX;
    private float playerStartX;
    private float fullDistance;
    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        endLineX = endLine.position.x;
        playerStartX = player.position.x;
    }

    void Update()
    {
        playerX = player.position.x;
        float progressValue = Mathf.InverseLerp(playerStartX, endLineX, playerX);
        UpdateProgressFill(progressValue);
    }

    // Update is called once per frame
    public void UpdateProgressFill(float newProgress)
    {
        _slider.value = newProgress;
    }

    
}
