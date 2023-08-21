using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject[] objFalse;
    public SOInt enemys;
    public GameManager gameManager;
    public GameObject end;

    private void Start()
    {
        enemys.value = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            gameManager.openMenu = true;
            Time.timeScale = 0.0f;
            foreach (GameObject obj in objFalse)
            {
                obj.SetActive(false);
            }
            end.SetActive(true);
        }
    }
}