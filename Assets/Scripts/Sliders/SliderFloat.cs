using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DataBase;
public class SliderFloat : MonoBehaviour
{
    [SerializeField]
    Settings.UISettingsFloat setting;
    [SerializeField] 
    TextMeshProUGUI sliderText;
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = Settings.GetValue(setting);
        slider.onValueChanged.AddListener((v) => {
            sliderText.SetText("{0:2}", v);
            Settings.SetValue(setting, v);
        });
    }
}
