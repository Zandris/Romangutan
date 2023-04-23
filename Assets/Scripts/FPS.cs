using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text text;

    private float updateTimer = 0.2f;

    void Update()
    {
        updateTimer -= Time.deltaTime;
        if(updateTimer <= 0) {
            text.text = Mathf.Round(1f / Time.unscaledDeltaTime).ToString();
            updateTimer = 0.2f;
        }
        //text.text = (Mathf.Round(1 / Time.deltaTime)).ToString();
    }
}
