using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + PlayerStats.money.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        moneyText.text = "$" + PlayerStats.money.ToString();
    }
}
