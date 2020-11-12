using UnityEngine;
using UnityEngine.InputSystem;


public class Bulletpointer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
