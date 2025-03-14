using DG.Tweening;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform trackTransform = null;
    [SerializeField]
    private float offsetPerTap = 200.0f;
    private float currentPosition = 0.0f;

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

    public void AdvanceTrack()
    {
        currentPosition -= offsetPerTap;
        trackTransform.DOMoveY(currentPosition, 0.2f);
    }
}
