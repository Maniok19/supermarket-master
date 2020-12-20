using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    float CurrentBalance;
    public Text CurrentBalanceText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBalance = 5;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
    }

    public void AddToBalance(float amt)
    {
        CurrentBalance += amt;
        CurrentBalanceText.text = CurrentBalance.ToString("C2");
    }
    public bool CanBuy(float AmtToSpend)
    {
        if (AmtToSpend > CurrentBalance)
            return false;
        else
            return true;
    }

}



