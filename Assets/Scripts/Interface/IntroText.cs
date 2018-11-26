using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

    public GameObject IntroductionText;
	
	public void toggleIntroductionText()
    {
        IntroductionText.SetActive(!IntroductionText.activeSelf);
    }

    public void FixedUpdate()
    {
        if (IntroductionText.activeSelf)
            if (IntroductionText.GetComponent<Image>() != null)
                if (IntroductionText.GetComponent<Image>().color.a < 255) {
                    Color color = IntroductionText.GetComponent<Image>().color;
                    color.a += 1 * Time.deltaTime;
                    IntroductionText.GetComponent<Image>().color = color;
                };
    }
}
