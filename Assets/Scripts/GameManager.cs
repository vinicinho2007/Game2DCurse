using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instante;
    public GameObject prefPlayer, gameOver;
    public Transform position;
    public float animDuration, delayOpenGameOver, animDurationGameOver;
    private List<GameObject> objs;

    private void Start()
    {
        objs = new List<GameObject>();
        if (instante == null)
        {
            instante = this;
        }
        else
        {
            Destroy(gameObject);
        }
        StartPlayer();
    }

    private void StartPlayer()
    {
        GameObject obj = Instantiate(prefPlayer, position);
        obj.transform.DOScale(0, animDuration).From();
    }

    public IEnumerator GameOver()
    {
        gameOver.SetActive(true);
        foreach (Transform obj in gameOver.GetComponentsInChildren<Transform>())
        {
            if (obj != gameOver.transform&&obj.gameObject.activeInHierarchy)
            {
                objs.Add(obj.gameObject);
                obj.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(delayOpenGameOver);
        for(int i =0;i<objs.Count;i++)
        {
            objs[i].gameObject.SetActive(true);
            objs[i].transform.DOScale(0, animDurationGameOver).From();
        }
    }
}