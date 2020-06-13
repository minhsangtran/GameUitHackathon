using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhSat : MonoBehaviour {

    public static Vector3 vitri;
    public Vector3 target;

	void Start () {
        NhanVatPhanDienController.isDung = true;
	}
	
	void Update () {
      Vector3 pos = (vitri - transform.position) * 0.1f * Time.timeScale;
      transform.Translate(pos);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "nvpd")
        {
            Destroy(gameObject,1);
        }
    }

}
