using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XSizeSlider : MonoBehaviour
{
    [SerializeField] private Slider _xSizeSlider;
    [SerializeField] private TextMeshProUGUI _xSizeSliderText;
    
    void Start()
    {
        _xSizeSlider.onValueChanged.AddListener((v) => {
            _xSizeSliderText.text = v.ToString("0");
            MapGenerator.xSize = (int) v;
        });
    }
}
