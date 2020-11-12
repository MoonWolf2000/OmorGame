using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public SceneAsset transition;
    public Vector2 playerPosition;
    public VectorValue playerTransitionPosition;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerTransitionPosition.initialValue = playerPosition;
            SceneManager.LoadScene(transition.name);
        }
    }
}
