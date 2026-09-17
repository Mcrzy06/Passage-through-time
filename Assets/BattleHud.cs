using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    public Text nameText;
    public Slider HPslider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHud(Unit unit)
    {
      nameText.text = unit.unitName;
      HPslider.maxValue = unit.maxHP;
      HPslider.value = unit.currentHp;
    }


}