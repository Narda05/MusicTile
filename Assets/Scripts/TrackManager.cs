using DG.Tweening;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform trackTransform = null;
    [SerializeField]
    private float offsetPerTap = 200.0f;
    private float currentPosition = 0.0f;
    private int currentBarIndex = 0;

    static private TrackManager instance = null;
    static public TrackManager Instance {  get { return instance; } }

    private void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        currentPosition = trackTransform.position.y;
    }
    public int GetCurrentBarIndex()
    {
        return currentBarIndex;
    }
    public void AdvanceTrack()
    {
        // keep track of the current bar index
        ++currentBarIndex;
        currentPosition -= offsetPerTap;
        trackTransform.DOMoveY(currentPosition, 0.2f);
    }
}
