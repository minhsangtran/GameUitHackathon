using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject pnEndGame;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    private int gamePoint = 0;
    AudioSource audio;

    public GameObject nvPhanDien;
    private Vector3 posNvPhanDien;
    private Vector3 posNgoiNha;
    private float minXnv = -4.8f, maxXnv = 4.8f, minYnv = -2.8f, maxYnv = 1.9f;
    private float timeToaNhanVat;
    public float timeHienTai;
    private Vector3 posHoDen;
    private float timeHienTai2;
    private float timeHienTai3;

    public bool isNhanVat = false;
    public GameObject HoDen;
    public GameObject ngoiNha;
    public AudioClip music;
    public AudioClip musicEndGame;
    

    //tạo ra nhân vật phản diện
    void CreateNhanVat()
    {
        
        if((5.5f - Camera.main.ScreenToViewportPoint(Input.mousePosition).x) > 5)
        {
            posNvPhanDien = new Vector3(Random.Range(maxXnv - 2, maxXnv), Random.Range(minYnv, maxYnv), 0);
        }
        else
        {
            posNvPhanDien = new Vector3(Random.Range(minXnv - 2, minXnv), Random.Range(minYnv, maxYnv), 0);
        }
        GameObject nvpd = Instantiate(nvPhanDien, posNvPhanDien, Quaternion.identity);
        isNhanVat = true;
    }

    //tạo hố đen
    void CreateHoDen()
    {
        posHoDen = new Vector3(Random.Range(minXnv, maxXnv), Random.Range(minYnv, maxYnv), 0);
       
        GameObject hd = Instantiate(HoDen, posHoDen, Quaternion.identity);
        Destroy(hd, 3);
    }
    // tao ngoi nha 
    void CreateNgoiNha()
    {

        if ((5.5f - Camera.main.ScreenToViewportPoint(Input.mousePosition).x) > 5)
        {
            posNgoiNha = new Vector3(Random.Range(maxXnv - 2, maxXnv), Random.Range(minYnv, maxYnv), 0);
        }
        else
        {
            posNgoiNha = new Vector3(Random.Range(minXnv - 2, minXnv), Random.Range(minYnv, maxYnv), 0);
        }
        GameObject NgoiNha = Instantiate(ngoiNha, posNgoiNha, Quaternion.identity);
        Destroy(NgoiNha, 3);
    }


    void Start () {
        Time.timeScale = 1;
        pnEndGame.SetActive(false);
        audio = gameObject.GetComponent<AudioSource>();
        timeHienTai = Time.time;
        timeToaNhanVat = 3;
        //HoDen = GameObject.FindGameObjectWithTag("HoDen");
        timeHienTai2 = Time.time;
        timeHienTai3 = Time.time;
        audio.clip = music;
        audio.Play();
    }
	
	
	void Update () {
        //if(Time.time > timeHienTai + timeToaNhanVat && !isNhanVat)
        
        if(!isNhanVat)
        {
            if(Time.time > timeHienTai + 1)
            {
                timeHienTai = Time.time;
                CreateNhanVat();
            }
            //timeHienTai = Time.time;
        }
        if(Time.time > timeHienTai2 + 7)
        {
            timeHienTai2 = Time.time;
            CreateHoDen();
        }

        // ngoi nha
        if(Time.time > timeHienTai3 + 6)
        {
            timeHienTai3 = Time.time;
            CreateNgoiNha();
            
        }
	}

    public void EndGame()
    {
        audio.clip = musicEndGame;
        audio.Play();
        audio.loop = false;
        pnEndGame.SetActive(true);
        Time.timeScale = 0;
    }



    public void GetPoint2()
    {
        gamePoint += 5;
        txtPoint.text = "Point: " + gamePoint;
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }
}
