using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarveBar : MonoBehaviour
{
    public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxStarve(int starve)
	{
		slider.maxValue = starve;
		slider.value = starve;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetStarve(int starve)
	{
		slider.value = starve;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
