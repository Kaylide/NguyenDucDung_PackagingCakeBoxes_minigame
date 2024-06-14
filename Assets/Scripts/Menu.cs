using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //button Play function
    public void ButtonPlay()
    {
        Application.LoadLevel("Level1");
    }

    //button Guild function
    public void ButtonGuild()
    {
        Application.LoadLevel("htp");
    }

    //button exit
    public void ButtonExit()
    {
        Application.LoadLevel("Menu");
    }
}
