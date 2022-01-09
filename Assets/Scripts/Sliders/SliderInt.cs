using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DataBase;

namespace sliders
{
    public class SliderInt : MonoBehaviour
    {
        [SerializeField]
        Settings.UISettingsInt setting;
        [SerializeField] 
        TextMeshProUGUI sliderText;
        private Slider slider;
        
        void Start()
        {
            slider = GetComponent<Slider>();
            slider.value = (float) Settings.GetValue(setting);
            slider.onValueChanged.AddListener((v) => {
                sliderText.text = v.ToString("0");
                Settings.SetValue(setting, (int) v);
            });
        }
    }
}