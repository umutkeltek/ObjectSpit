using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    [SerializeField] public int multiplyValue;
    public MeshRenderer mCube;
    [SerializeField] TextMeshProUGUI mText;
    void Start()
    {
        mText.text = "x" + multiplyValue.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag == "Bullet")
        {   Destroy(collision.transform);
            //GameManager.Instance.currentScene = GameManager.Instance.currentScene + 1;
            LevelManager.Instance.EndLevel(multiplyValue);
            //GameManager.Instance.NextLevel();
            
        }
        
    }
}
