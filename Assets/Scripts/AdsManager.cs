using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    private string androidGameId = "";
    [SerializeField]
    private bool testMode = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Advertisement.Initialize(androidGameId, testMode, this);
    }


    public void OnInitializationComplete()
    { 
        Debug.Log("Unity Ads initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    { 
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
