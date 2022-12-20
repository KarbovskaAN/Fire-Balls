using UnityEngine;

public class GameTapInput : MonoBehaviour
{

   private bool _isTap;

   public bool IfTap()
   {
      if (_isTap)
      {
         _isTap = false;
         return true;
      }

      return false;
   }

   public void Tap()
   {
      _isTap = true;
   }
}









