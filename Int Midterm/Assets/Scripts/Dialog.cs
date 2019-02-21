using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Serializable stuff shows up in the inspector
public class Dialog 
{
    //This script is used to pass "Dialog" objects into our DialogManager

    public string name;

    //Sets up what our text box will look like the in the inspector
    [TextArea(3,10)]
    public string[] sentences;

}
