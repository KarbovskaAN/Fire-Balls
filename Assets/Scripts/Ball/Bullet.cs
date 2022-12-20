using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
   private Tower _tower;
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.TryGetComponent(out Figure figure))
      {
         _tower.DestroyFigure(figure);
         Destroy(gameObject);
      }

      Restart(collision);
   }

   public void Restart(Collision collision)
   {
      if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
      {
         DOTween.KillAll();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
   }

   public void SetTower(Tower tower)
   {
      _tower = tower;
   }
}
