using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimButton : MonoBehaviour
{
    public List<GameObject> buttonsObj;
    public float delay, animDuration;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        CloseButtons();
        ShowButtons();
    }

    private void CloseButtons()
    {
        foreach (GameObject obj in buttonsObj)
        {
            obj.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        StartCoroutine(CoroutineButtonsShow());
    }

    IEnumerator CoroutineButtonsShow()
    {
        foreach (GameObject obj in buttonsObj)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(true);
            obj.transform.DOScale(0, animDuration).SetEase(ease).From();
        }
    }
}