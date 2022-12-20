using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   public void FinishLvl()
   {
      int level = PlayerPrefs.GetInt("Level");
      level += 1;
      int figureCountForNextLevel =  1 + PlayerPrefs.GetInt("FigureAmount") ;
      PlayerPrefs.SetInt("FigureAmount", figureCountForNextLevel);
      PlayerPrefs.SetInt("Level" , level);
      DOTween.KillAll();
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
