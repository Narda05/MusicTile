using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIAnimations : MonoBehaviour
{
    [Header("Pantallas")]
    public RectTransform gameOverScreen;
    public RectTransform highScoreScreen;

    [Header("Botones")]
    public Button[] animatedButtons;

    public float animStartDelay = 0.0f;

    private void OnEnable()
    {
        // Animar botones
        foreach (Button btn in animatedButtons)
        {
            if (btn != null)
            {
                RectTransform btnTransform = btn.GetComponent<RectTransform>();
                btnTransform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(UnityEngine.Random.Range(0.0f, animStartDelay));
                btn.onClick.AddListener(() => AnimateButtonClick(btnTransform));
            }
        }
    }

    public void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.localScale = Vector3.zero; // Ocultar al inicio
            gameOverScreen.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }
    }

    public void ShowHighScoreScreen()
    {
        if (highScoreScreen != null)
        {
            highScoreScreen.localScale = Vector3.zero; // Ocultar al inicio
            highScoreScreen.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }
    }

    void AnimateButtonClick(RectTransform btnTransform)
    {
        if (btnTransform != null)
        {
            btnTransform.DOPunchScale(Vector3.one * 0.2f, 0.2f, 10, 1);
        }
    }
}
