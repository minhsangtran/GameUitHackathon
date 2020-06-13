using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour {

    //public GameObject target;
    public float moveSpeed;
    Vector3 mousePos;
    float minX = -7f;
    float maxX = 6f;
    float minY = -4.2f;
    float maxY = 3.7f;
    public NhanVatPhanDienController nvpd;

    bool isStartGame;

    private GameObject gameController;


    void Start () {
        moveSpeed = 50;
        mousePos = transform.position;
        isStartGame = false;
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            isStartGame = true;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            isStartGame = false;
        }
        if (isStartGame)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(Mathf.Clamp(mousePos.x,minX,maxX),Mathf.Clamp(mousePos.y +2,minY,maxY), 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NgoiNha")
        {
            Debug.Log("cham nha");
            nvpd.GetComponent<NhanVatPhanDienController>().Huy();
        }

        //Destroy(collision.gameObject);
        if (collision.tag != "HoDen" && collision.tag != "NgoiNha" && collision.tag != "CanhSat")
        gameController.GetComponent<GameController>().EndGame();

       
    }
}
