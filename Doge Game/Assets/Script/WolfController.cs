using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour {

    private GameObject boom;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;


    public float minBoomTime = 2;
    public float maxBoomTime = 4;   // tạo random nén boom chậm lại.
    private float lastBoomTime = 0;
    private float boomTime = 0;

    private float threwBoomTime = 0.5f;

    private GameObject sheep;

    
    private GameObject gameController;


	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        UpdateBoomTime();
        sheep = GameObject.FindGameObjectWithTag("Player");
        
	}
    //private bool isChangeAnim = false;
	void Update () {
        //if(Time.time >= lastBoomTime + boomTime - threwBoomTime && !isChangeAnim)
        //{
        //    anim.SetTrigger("Boom");
        //    isChangeAnim = true;
        //}
        
        if (Time.time > lastBoomTime + boomTime)
        {
            ThrowBoom();
            //isChangeAnim = false;

            //anim.SetTrigger("NotBoom");
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThrowBoom()    // sử dụng 1 khoảng thời gian để ném boom
    {       //anim.SetTrigger("NotBoom");
        int t = Random.Range(1, 4);
        {
            switch(t)
            {
                case 1:
                    {
                        boom = obj1;
                        break;
                    }
                case 2:
                    {

                        boom = obj2;
                        break;
                    }
                case 3:
                    {
                        boom = obj3;
                        break;
                    }
                default:
                    {
                        boom = obj1;
                        break;
                    }
            }
        }
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity);
        /*lấy đối tượng vừa được tạo di chuyển tới con cừu. nên cần lấy toạ độ con cừu*/
        bom.GetComponent<BoomController>().target = sheep.transform.position;
        UpdateBoomTime();
    }
}
