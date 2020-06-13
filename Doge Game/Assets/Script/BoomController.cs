using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour {

    public Vector3 target;
    private float moveSpeed = 1f;
    public float timeDestroy = 2;
    public GameObject explor;
    public GameObject gameController;
    public GameObject audioSource;
    
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        //audio = gameObject.GetComponent<AudioSource>();
        Destroy(gameObject, timeDestroy);
        //audioSource = GameObject.FindGameObjectWithTag("audioSourse");

    }

    void Update () {
        transform.Translate((target - transform.position) * moveSpeed * Time.deltaTime);
    }
    

    public void OnDestroy()
    {
        //GameObject exp = Instantiate(explor, gameObject.transform.position, Quaternion.identity) as GameObject;
        //Destroy(exp, 0.5f);
        //audio2.Play();
        NhanVatPhanDienController.dem++;
        gameController.GetComponent<GameController>().GetPoint();
        GameObject obj = Instantiate(audioSource,transform.position,Quaternion.identity);
        Destroy(obj, 0.7f);
    }

    

}
