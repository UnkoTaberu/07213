
 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    //　インフォメーションテキストに表示する文字列
    [SerializeField]
    private string informationString;
    //　インフォメーションテキスト
    [SerializeField]
    private Text informationText;
    //　自身の親のCanvasGroup
    private CanvasGroup canvasGroup;
    //hpbar用
    [SerializeField]
    HpBarCtrl hbc;
    //item使用用
    public static Text itext;
    public static Text components;
    [SerializeField]
    ItemList ilist;
    // キャンセルボタン用
    public int canselBtn = 0;

    void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();
        //returnButton = transform.parent.Find("Exit").gameObject;

        //hpbar用
        Slider slider = GameObject.Find("Slider").GetComponent<Slider>();
        hbc = slider.gameObject.GetComponent<HpBarCtrl>();

        //item使用用
        GameObject test = GameObject.Find("ItemMenuSet");
        ilist = test.gameObject.GetComponent<ItemList>();
    }

    //　ボタンの上にマウスが入った時、またはキー操作で移動してきた時
    public void OnSelected()
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            //　イベントシステムのフォーカスが他のゲームオブジェクトにある時このゲームオブジェクトにフォーカス
            if (EventSystem.current.currentSelectedGameObject != gameObject)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
            //informationText.text = informationString;
        }
    }

    //　ステータスウインドウを非アクティブにする
    public void DisableWindow()
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            //　ウインドウを非アクティブにする
            transform.root.gameObject.SetActive(false);

            // キャンセルボタンが押された処理
            canselBtn = 1;
        }
    }

    //　他の画面を表示する
    public void WindowOnOff(GameObject window)
    {
        if (canvasGroup == null || canvasGroup.interactable)
        {
            Camera.main.GetComponent<OperationStatusWindow>().ChangeWindow(window);
        }
    }

    //　アイテム使用確認
    public void ItemMenu(GameObject window)
    {

        if (canvasGroup == null || canvasGroup.interactable)
        {
            Camera.main.GetComponent<OperationStatusWindow>().ItemChangeWindow(window);
        }

        components = this.gameObject.GetComponentInChildren<Text>();
        itext = GameObject.Find("ItemText").GetComponent<Text>();
        itext.text = components.text;

    }

    public void ItemuUse()
    {

        //if (itext.text == "かなしばりの杖")
        //{

        //}
        //else if (itext.text == "やりすごしの壺")
        //{

        //}
        //else if (itext.text == "バシルーラの杖")
        //{

        //}
        //else if (itext.text == "飛びつきの杖")
        //{

        //}
        //else if (itext.text == "高飛び草")
        //{

        //}
        //else if (itext.text == "自爆の巻物")
        //{

        //}

        if (itext.text == "煙草")
        {

            hbc.HpRecovery();
        }
        //else if (itext.text == "一時しのぎの杖")
        //{

        //}
        //else if (itext.text == "ふきとばしの杖")
        //{

        //}
        //else if (itext.text == "場所替えの杖")
        //{

        //}

        itext.text = "";
        components.text = "";
        itext.text = ilist.UnsetIlist();

    }

    //　ゲーム終了ボタンを押したら実行する
    public void GameEnd()
    {   
       
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
		                            Application.Quit();
        #endif
                      
    }

    //　階層表示のシーンに遷移
    public void TheSceneLord()
    {
        SceneManager.LoadScene("Scene");
    }

    //　タイトルのシーンに遷移
    public void TitleSceneLord()
    {

        SceneLord.score = 1;
        SceneManager.LoadScene("Game_Title");
    }

}