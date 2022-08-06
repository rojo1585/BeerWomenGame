using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtContrroller : MonoBehaviour
{
    public Slider healtSlider;

    public void ChangeSlider(float change){
        healtSlider.value -= change;
    }
}
