using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace sliders
{
    public class DronesSlider : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Slider _dronesSlider;
        [SerializeField] private TextMeshProUGUI _dronesSliderText;
        #endregion

        #region Main Methods
        void Start()
        {
        _dronesSlider.onValueChanged.AddListener((v) => {
            _dronesSliderText.text = v.ToString("0");
            DataBase.Settings.NbDronesToSpawn = (int) v;
        });
    }

        void Update()
        {

        }
        #endregion

        #region Custom Methods

        #endregion
    }
}
