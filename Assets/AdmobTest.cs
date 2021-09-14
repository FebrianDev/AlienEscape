using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobTest : MonoBehaviour
{
    
    string adUnitId = "ca-app-pub-7236868754898666~3805121676";

    private InterstitialAd interstitial;

    string idInterstitial = "ca-app-pub-7236868754898666/9533102833";
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(adUnitId);
        
        RequestIntertstitial();
    }

    public void RequestIntertstitial()
    {

        this.interstitial = new InterstitialAd(idInterstitial);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void Update()
    {
        if (DataPlayer.isGameOver)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
    }

}