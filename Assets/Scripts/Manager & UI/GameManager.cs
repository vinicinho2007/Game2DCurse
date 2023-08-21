using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cinemachine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("GameManager")]
    public static GameManager instante;

    [Header("Coins")]
    public SOInt coinsSO;
    public SOBool resetCoinSO;

    [Header("Player")]
    public CinemachineVirtualCamera cinemachine;
    public Transform position;
    public GameObject prefPlayer;
    public float animDuration;

    [Header("GameOver")]
    public End end;
    public GameObject gameOver;
    public float animDurationGameOver;

    [Header("Menu Pause")]
    public GameObject menuPause;
    public float animDurationMenuPause, transationSnapshot;
    public AudioMixerSnapshot snapshotMenu, snapshotGameplay;
    public bool openMenu;

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
        if (resetCoinSO.value)
        {
            coinsSO.value = 0;
        }
    }

    private void StartPlayer()
    {
        GameObject obj = Instantiate(prefPlayer, position);
        obj.transform.DOScale(0, animDuration).From();
        cinemachine.Follow = obj.transform;
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!openMenu&&!gameOver.active&&!end.end.active)
        {
            OpenMenuPause();
        }
    }

    public void OpenMenuPause()
    {
        snapshotMenu.TransitionTo(transationSnapshot);
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(CoroutineAnim(menuPause, animDurationMenuPause));
        openMenu = true;
    }

    public void CloseMenuPause()
    {
        Time.timeScale = 1.0f;
        snapshotGameplay.TransitionTo(transationSnapshot);
        Cursor.lockState = CursorLockMode.Locked;
        openMenu = false;
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
        Invoke(nameof(StopTime), durationAnim);
    }

    private void StopTime()
    {
        Time.timeScale = 0.0f;
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