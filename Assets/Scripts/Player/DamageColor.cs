using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColor : MonoBehaviour
{
    public Color colorDamage;
    private List<Color> _colors;
    private List<SpriteRenderer> _spritesRenderes;
    private void Start()
    {
        StartColor();
    }

    private void StartColor()
    {
        _spritesRenderes = new List<SpriteRenderer>();
        _colors = new List<Color>();
        foreach (Transform t in gameObject.GetComponentsInChildren<Transform>())
        {
            if (t.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer s = t.GetComponent<SpriteRenderer>();
                _spritesRenderes.Add(s);
                _colors.Add(s.color);
            }
        }
    }

    public void ColorDamage()
    {
        for (int i = 0; i < _spritesRenderes.Count; i++)
        {
            _spritesRenderes[i].color = colorDamage;
        }
        Invoke(nameof(ColorOriginal), .3f);
    }

    private void ColorOriginal()
    {
        for (int i = 0; i < _spritesRenderes.Count; i++)
        {
            _spritesRenderes[i].color = _colors[i];
        }
    }
}