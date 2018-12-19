
 
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

    // キャンセルボタン用
    public int canselBtn = 0;

    void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();
        //returnButton = transform.parent.Find("Exit").gameObject;
    }


    void OnEnable()
    {
        //　装備アイテム選択中にステータス画面を抜けた時にボタンが無効化したままの場合もあるので立ち上げ時に有効化する
        GetComponent<Button>().interactable = true;
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

    ////　ボタンから移動したら情報を削除
    //public void OnDeselected()
    //{
    //    informationText.text = "";
    //}

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

    public void SceneLord()
    {
        SceneManager.LoadScene("Scene");
    }

}