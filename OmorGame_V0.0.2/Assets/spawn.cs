using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private GameObject GO_Player;

    private void Awake()
    {
        GO_Player = FindObjectOfType<Player>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        GO_Player.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
