using System;
using UnityEngine;
public class JumpItem : MonoBehaviour
{
    public static event Action<float> OnSpeedCollected;
    public float JumpMultiplier = 5.5f;

    public void Collect()
    {
        OnSpeedCollected?.Invoke(JumpMultiplier);
        Destroy(gameObject);
    }

   private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("jump Boost activate!");
        Collect();
    }
  }
}
