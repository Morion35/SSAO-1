using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {


    public void Volume(float volume)
    {
        AudioListener.volume = volume;
    }
}
