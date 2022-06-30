using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    
#if UNITY_IOS
    string gameId="4821647";
#else
    string gameId = "4821646";
#endif
    private void Start()
    {
        Advertisement.Initialize(gameId);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            if (Advertisement.IsReady("Rewarded_Android"))
            {   Debug.Log("READY");
                Advertisement.Show("Rewarded_Android");
            }
        }
    }
    
}
