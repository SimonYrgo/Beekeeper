using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExtractorTimer : MonoBehaviour
{
    public Slider slider;

    public TMP_Text timerText;

    ExtractorMoveLerp extractorMoveLerp;

    float totalTime = 100f;

    float sliderDefautValue; 


    // Start is called before the first frame update
    void Start()
    {
        extractorMoveLerp = GameObject.FindObjectOfType<ExtractorMoveLerp>();

        sliderDefautValue = slider.minValue;   // ..om vi �ndrar i Unity p� Sliderns v�rde s� beh�ver vi inte �ndra den h�r

    }






    // Update is called once per frame
    void Update()
    {

        if (extractorMoveLerp.isLerping) // Detta �r en klockfunktion som r�knar ner i tid p� Slungan och p�verkas av hur snabbt man s�tter hastigheten i slidern
        {

            totalTime -= Time.deltaTime * (1 + slider.value -sliderDefautValue); // s� som inst�llt nu s� blir slidern 0 i v�rde och vi l�gger till1 f�r att den ska r�r sig alls p� klockan
            timerText.text = Mathf.Round(totalTime).ToString();

            if (totalTime <= 0) // m�ste vara <= f�r time.Deltatime kan bli mindre �n 0 beroende p� n�r v�r funktion kallas
            {
                extractorMoveLerp.isLerping = false;

                timerText.text = "Finished!!!";
            }

        }
        
       

    }
}
