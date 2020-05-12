using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Unitychanのオブジェクト読み込みよう
    private GameObject UnitychanObj;

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unitychaの現在位置から少し先の位置
    private float posUnitychanPlus;
    //アイテム間隔更新用
    private float posItemInterval;

    // Use this for initialization
    void Start()
    {
        //Unitychanのオブジェクト情報所得
        this.UnitychanObj = GameObject.Find("unitychan");
        posItemInterval = startPos ;

    }
    // Update is called once per frame
    void Update()
    {
        posUnitychanPlus = this.UnitychanObj.transform.position.z + 40.0f;
        //Unitychanの位置から+40先がstartPosになったら一定間隔でオブジェクト作成
        if (posUnitychanPlus >= startPos && posUnitychanPlus <= goalPos)
        {
            //一定の距離ごとにアイテムを生成
            if (posUnitychanPlus >= posItemInterval)
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, posUnitychanPlus);
                    }
                }
                else
                {

                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, posUnitychanPlus + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, posUnitychanPlus + offsetZ);
                        }
                    }
                }
                //一度アイテムを作成したら+15先まで作成しない
                posItemInterval += 15;
            }
        }
    }
}