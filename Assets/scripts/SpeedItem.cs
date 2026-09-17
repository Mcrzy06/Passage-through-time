using System;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    public static event Action<float> OnSpeedCollected;
    public float speedMultiplier = 1.5f;

    public void Collect()
    {
        OnSpeedCollected?.Invoke(speedMultiplier);
        Destroy(gameObject);
    }

   private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("Speed Boost activate!");
        Collect();
    }
  }
}