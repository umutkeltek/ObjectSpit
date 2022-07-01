using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoSingleton<AdManager>
{
    
#if UNITY_IOS
    string gameId="4821647";
#else
    string gameId = "4821646";
#endif
    private void Start()
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner");
    }
    public void showAds()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {   
            Advertisement.Show("Rewarded_Android");
        }
    }
    
}
