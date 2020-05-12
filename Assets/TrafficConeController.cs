using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficConeController : MonoBehaviour {
    //コーンが画面外に出るときのUnitychanとのｚ距離
    private float visiblePosZ = -7.0f;

    //Unitychanのオブジェクト読み込みよう
    private GameObject UnitychanObj;

    // Use this for initialization
    void Start () {
        //Unitychanのオブジェクト情報所得
        this.UnitychanObj = GameObject.Find("unitychan");

    }

    // Update is called once per frame
    void Update () {
        //画面外に来たらこのオブジェクトをデストロイ
        if (this.UnitychanObj.transform.position.z > this.transform.position.z - this.visiblePosZ)
        {
            Destroy(gameObject);
        }

    }
}
