using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject InfoPanelInspector;
    public static GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        InfoPanel = InfoPanelInspector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
