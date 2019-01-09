using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Inspector
    [SerializeField] private Button buttonComponent;

    // Use this for initialization
    private void Start()
    {
        buttonComponent.Select();
    }

    // Buttonにフォーカス
    private void FocusButton()
    {
        // Normal Color → Highlighted Color
        
    }
}