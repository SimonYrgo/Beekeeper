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

        sliderDefautValue = slider.minValue;   // ..om vi ändrar i Unity på Sliderns värde så behöver vi inte ändra den här

    }






    // Update is called once per frame
    void Update()
    {

        if (extractorMoveLerp.isLerping) // Detta är en klockfunktion som räknar ner i tid på Slungan och påverkas av hur snabbt man sätter hastigheten i slidern
        {

            totalTime -= Time.deltaTime * (1 + slider.value -sliderDefautValue); // så som inställt nu så blir slidern 0 i värde och vi lägger till1 för att den ska rör sig alls på klockan
            timerText.text = Mathf.Round(totalTime).ToString();

            if (totalTime <= 0) // måste vara <= för time.Deltatime kan bli mindre än 0 beroende på när vår funktion kallas
            {
                extractorMoveLerp.isLerping = false;

                timerText.text = "Finished!!!";
            }

        }
        
       

    }
}
