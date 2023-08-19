using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("GameManager")]
    public static GameManager instante;

    [Header("Coins")]
    public SOInt coinsScriptableObjects;

    [Header("Player")]
    public Transform position;
    public GameObject prefPlayer;
    public float animDuration;

    [Header("GameOver")]
    public GameObject gameOver;
    public float animDurationGameOver;

    [Header("MenuPause")]
    public bool menuPauseBool;
    public GameObject menuPause;
    public float animDurationMenuPause;

    private void Start()
    {
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!menuPauseBool)
        {
            MenuPause();
        }
    }

    public void MenuPause()
    {
        if (!menuPause.activeInHierarchy && !gameOver.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(CoroutineAnim(menuPause, animDurationMenuPause));
        }
        else if (menuPause.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            menuPause.SetActive(false);
        }
    }

    private List<GameObject> AddsObjsAnimacao(GameObject obj)
    {
        List<GameObject> objs = new List<GameObject>();
        foreach (Transform t in obj.GetComponentsInChildren<Transform>())
        {
            if (t != obj.transform)
            {
                objs.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
        return objs;
    }

    private void Animacao(float durationAnim, List<GameObject> listObjs)
    {
        for (int i = 0; i < listObjs.Count; i++)
        {
            listObjs[i].gameObject.SetActive(true);
            listObjs[i].transform.DOScale(0, durationAnim).From();
        }
    }

    public void GameOver()
    {
        if (menuPause.activeInHierarchy)
        {
            AddsObjsAnimacao(menuPause);
            menuPause.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(CoroutineAnim(gameOver, animDurationGameOver));
    }

    private IEnumerator CoroutineAnim(GameObject obj, float durationAnim)
    {
        obj.SetActive(true);
        List<GameObject> listObjs = AddsObjsAnimacao(obj);
        yield return new WaitForSeconds(0);
        Animacao(durationAnim, listObjs);
    }
}