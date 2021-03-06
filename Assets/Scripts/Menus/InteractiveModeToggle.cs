using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractiveModeToggle : MonoBehaviour
{
    Toggle m_Toggle;
    [SerializeField] private TextMeshProUGUI m_Text;

    void Start()
    {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(m_Toggle);
        });

        //Initialise the Text to say the first state of the Toggle
        m_Text.text = "First Value : " + m_Toggle.isOn;
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        m_Text.text = "New Value : " + m_Toggle.isOn;
    }
}
