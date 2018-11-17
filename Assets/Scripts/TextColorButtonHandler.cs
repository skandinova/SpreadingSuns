using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorButtonHandler : MonoBehaviour 
    {

    public Color[] colorArray;

    public void SetColor(int colorArrayIndex) 
    {
        GetComponent<Text>().color = colorArray[colorArrayIndex];
    }
}
