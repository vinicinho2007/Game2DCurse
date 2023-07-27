using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerItens : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI textCoins;
    public static ManagerItens instante;

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
    }

    private void Update()
    {
        textCoins.text = "x" + coins;
    }

    public void AddCoins()
    {
        coins++;
    }
}