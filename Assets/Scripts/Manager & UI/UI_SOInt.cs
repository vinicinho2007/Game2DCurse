using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_SOInt : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SOInt soInt;

    private void Update()
    {
        text.text = "x" + soInt.value;
    }
}