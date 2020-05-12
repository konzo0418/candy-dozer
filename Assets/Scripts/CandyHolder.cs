using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour
{
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;


    //キャンディのストック
    int candy = DefaultCandyAmount;
    //ストック回復までの秒数
    int counter;

    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    public int GetCandyAmount()
    {
        return candy;
    }

    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black;

        //キャンディのストック数を表示
        string label = "Candy : " + candy;

        //カウントしているときだけ表示
        if (counter > 0) label = label + " (" + counter + "s)";

        GUI.Label(new Rect(0, 0, 100, 30), label);
    }

    void Update()
    {
        //キャンディのストックがデフォルトより少ない
        //かつ回復カウントが進んでいなければカウントをスタート
        if (candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;

        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        candy++;
    }
}
