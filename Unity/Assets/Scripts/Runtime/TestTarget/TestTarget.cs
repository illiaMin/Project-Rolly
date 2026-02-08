using System;
using UnityEngine;

public class TestTarget : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log("hit");
   }
}
