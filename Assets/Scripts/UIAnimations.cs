using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour
{
    [Header("Pantallas")]
    public RectTransform gameOverScreen;
    public RectTransform highScoreScreen;

    [Header("Botones")]
    public Button[] animatedButtons;

    void Start()
    {
        // Animar pantallas cuando aparezcan
        if (gameOverScreen != null)
            gameOverScreen.localScale = Vector3.zero; // Ocultar al inicio

        if (highScoreScreen != null)
            highScoreScreen.localScale = Vector3.zero; // Ocultar al inicio

        // Animar botones
        foreach (Button btn in animatedButtons)
        {
            RectTransform btnTransform = btn.GetComponent<RectTransform>();
            btnTransform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo);
            btn.onClick.AddListener(() => AnimateButtonClick(btnTransform));
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    public void ShowHighScoreScreen()
    {
        highScoreScreen.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    void AnimateButtonClick(RectTransform btnTransform)
    {
        btnTransform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 10, 1);
    }
}
