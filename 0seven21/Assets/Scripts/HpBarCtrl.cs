using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる
using UnityEngine.SceneManagement;

public class HpBarCtrl : MonoBehaviour
{


    Slider _slider;
    public Image sliderImage;

    int _hp = 1000;


    void Start()
    {
        // スライダーを取得する
        _slider = this.GetComponent<Slider>();
        _slider.value = _hp;
    }


    void Update()
    {

        //Vector3 player = GameObject.Find("Player").transform.position;
        //Vector3 item = GameObject.Find("teki2(Clone)").transform.position;

        //アイテムの上に乗った時
        //if (player.x == item.x && player.y == item.y)
        //{


        //if (_hp < 1000)
        //{
        //_hp += 10;

        //// HPゲージに値を設定
        //_slider.value = _hp;
        //Debug.Log("ちくび");


        //}


        //}
        //else if (_hp > 0)
        //{

        if (_slider.value > 500)
        {
            sliderImage.color = new Color32(0, 255, 0, 255);
        }
        else if (_slider.value > 0)
        {
            sliderImage.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            SceneLord.score = 1;
            SceneManager.LoadScene("GameOver");
        }
        //    _hp -= 1;

        //    // HPゲージに値を設定
        //    _slider.value = _hp;
        //    Debug.Log("びんびいん");


        //}
        //if (_slider.value == 0){
        //    SceneManager.LoadScene("EndGame");
        //}


    }
    public void HpRecovery()
    {
        _hp = 1000;

        // HPゲージに値を設定
        _slider.value = _hp;
        Debug.Log("ちくび");
    }
    public void HpDamage()
    {
        _hp = _hp - 500;

        // HPゲージに値を設定
        _slider.value = _hp;
    }

}