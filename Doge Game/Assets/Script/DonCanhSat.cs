using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonCanhSat : MonoBehaviour {

    public GameObject canhSat;
    private Vector3 viTri;
    public AudioSource audio;
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        viTri = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.tag == "Player")
        {
            Debug.Log("ablo");
            GameObject bom = Instantiate(canhSat, transform.position, Quaternion.identity);
            bom.GetComponent<CanhSat>().target = viTri;
            audio.Play();
        }
    }
}
