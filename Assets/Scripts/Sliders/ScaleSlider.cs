using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScaleSlider : MonoBehaviour
{
    [SerializeField] private Slider _scaleSlider;
    [SerializeField] private TextMeshProUGUI _scaleSliderText;
    
    void Start()
    {
        _scaleSlider.onValueChanged.AddListener((v) => {
            _scaleSliderText.text = v.ToString("0");
            DataBase.Settings.Scale = v;
        });
    }
}
