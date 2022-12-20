using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
 public void RestartLevel()
 {
  DOTween.KillAll();
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 }
}
