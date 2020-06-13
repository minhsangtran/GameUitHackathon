using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
    public GameObject Huongdan, btExit;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void _PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void _Instruction()
    {
        Huongdan.SetActive(true);
        btExit.SetActive(true);
    }
    public void _ExitIntruction()
    {
        Huongdan.SetActive(false);
        btExit.SetActive(false);
    }
}
