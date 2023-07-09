using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefsOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.LoadFromPrefs();
    }
}
