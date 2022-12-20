using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Figure> _figures;
    public Finish finish;
    private TMP_Text _text;
    
    public void DestroyFigure(Figure figure)
    {
        _figures.Remove(figure);
        UpDateText();
        figure.Break();
        CheckFinish();
    }

    private void CheckFinish()
    {
        if (_figures.Count == 0)
        {
            finish.FinishLvl();
        }
    }

    public void CreatTower(TMP_Text text)
    {
        _text = text;
    }

    public void UpDateText()
    {
        int AmountFigure = _figures.Count;
        _text.text = AmountFigure.ToString();
    }
}
