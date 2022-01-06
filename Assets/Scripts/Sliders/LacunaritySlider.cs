using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LacunaritySlider : MonoBehaviour
{
    [SerializeField] private Slider _lacunaritySlider;
    [SerializeField] private TextMeshProUGUI _lacunaritySliderText;
    
    void Start()
    {
        _lacunaritySlider.onValueChanged.AddListener((v) => {
            _lacunaritySliderText.text = v.ToString("0");
            DataBase.Settings.Lacunarity = v;
        });
    }
}
