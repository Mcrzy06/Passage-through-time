using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscript : MonoBehaviour
{
    public GameObject start; 
    public GameObject player;
    public GameObject chaser; 
    public float respawnOffset = -2f; 

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {   
           SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
        
      
        { 
        
            Vector3 chaserNewPosition = start.transform.position;
            chaserNewPosition.x += respawnOffset;
            chaser.transform.position = chaserNewPosition;
        }
    }
}
