using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{

    public TextMeshProUGUI ThisTextField;
    public LifeController lifecontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisTextField.text = "HP " +lifecontroller.lifepoints;
    }
}
