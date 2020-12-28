using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MaglioneFramework
{
    public class Info : MonoBehaviour
    {
        public GameObject InfoPanelInspector;
        public static GameObject InfoPanel;
        public static GameObject EndPointRightStatic;
        public GameObject EndPointRight;

        public static GameObject EndPointLeftStatic;
        public GameObject EndPointLeft;
        // Start is called before the first frame update
        void Start()
        {
            EndPointRightStatic = EndPointRight;
            EndPointLeftStatic = EndPointLeft;
            InfoPanel = InfoPanelInspector;
        }
    }
}
