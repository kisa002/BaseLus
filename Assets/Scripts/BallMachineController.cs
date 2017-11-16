using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMachineController : MonoBehaviour {

    public GameObject ball;
    GameObject launch;

	// Use this for initialization
	void Start () {
        launch = GameObject.Find("Launch");
        ball = Resources.Load<GameObject>("Prefabs/ball");

        StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        Instantiate(ball, launch.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(5f);

        StartCoroutine(Shoot());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
