using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVatPhanDienController : MonoBehaviour {

    private float moveSpeed;
    public static int dem;
    public GameObject gameController;
    public bool coChamNha;
    public static bool isDung=false;

   // private bool isDung;

    void Start () {
        moveSpeed = 1.5f;
        dem = 0;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        coChamNha = false;
        isDung = false;
        
       // isDung = true;
    }
	
	void Update () {
        {
            if (-Camera.main.ScreenToWorldPoint(Input.mousePosition).x + transform.position.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;

            }

            Vector3 pos;
            Vector3 p = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 2, 0);

            if (isDung)
            {
                moveSpeed = 0;
                CanhSat.vitri = new Vector3(transform.position.x, transform.position.y, 0);
            }

            pos = (p - transform.position) * moveSpeed * Time.deltaTime;
            
            //transform.Translate((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * moveSpeed * Time.deltaTime);
            transform.Translate(pos);
            //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (dem >= 10|| isDung)
            {
                Destroy(gameObject,1.5f);
                coChamNha = false;
            }
        }
    }

    public void Huy()
    { 
    }
    private void OnDestroy()
    {
        gameController.GetComponent<GameController>().isNhanVat = false;
        gameController.GetComponent<GameController>().timeHienTai = Time.time;
        gameController.GetComponent<GameController>().GetPoint2();
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("HoDen"))
        {
            Destroy(gameObject);
        }
    }
    //gọi hàm endgame từ gamecontroller.
}
