using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    [SerializeField] private Slider manaSlider;
    public Gradient gradient;
    public Image fill;
    public Text manaText;
    [SerializeField] ManaManager manamana;

    // Start is called before the first frame update
    public void SetMaxMana(float mana)
    {
        manaSlider.maxValue = mana;
        manaSlider.value = mana;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetMana(float mana)
    {
        manaSlider.value = mana;
        fill.color = gradient.Evaluate(manaSlider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "Mana";
    }

}
