
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandledRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;

    Image backgroundImage, handleImage;
    public string type;


    Color backgroundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;


    private void Awake()
    {
        GetToggles();
        
        
    }

   
   
    private void GetToggles()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandledRectTransform.anchoredPosition;

        backgroundImage = uiHandledRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandledRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;
        toggle.onValueChanged.AddListener(OnSwitch);
    }


    public void OnSwitch(bool on)
    {
        //uiHandledRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
        uiHandledRectTransform.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .4f);
        //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor , .4f);
        //handleImage.color = on ? handleActiveColor : handleDefaultColor;
        handleImage.DOColor(on ? handleDefaultColor : handleDefaultColor, .4f);
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch); 
    }
}
