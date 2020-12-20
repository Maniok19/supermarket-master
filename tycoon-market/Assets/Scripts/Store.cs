using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
   
    float BaseStoreCost;
    float BaseStoreProfit = 2f;
    public Slider ProgressSlider;
    public gameManager GameManager;
    int StoreCount;
    public Text StoreCountText;
   

    float StoreTimer = 2f;
    float CurrentTimer = 0;
    bool StartTimer=false;
    // Start is called before the first frame update
    void Start()
    {
        StoreCount = 1;

        BaseStoreCost = 1.5f;

    }
    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if (CurrentTimer > StoreTimer)
            {
                StartTimer = false;
                CurrentTimer = 0f;
                
                    GameManager.AddToBalance(BaseStoreProfit * StoreCount);
            }
            ProgressSlider.value = CurrentTimer / StoreTimer;
        }
    }
    public void BuyOnClick ()
    {
        if (!GameManager.CanBuy(BaseStoreCost))
            return;
        StoreCount++;
        Debug.Log(StoreCount);
        StoreCountText.text = StoreCount.ToString();
            GameManager.AddToBalance(- BaseStoreCost);
       
    }
    public void StoreOnClick()
    {
        if (!StartTimer)
        { StartTimer = true; }
    }
}
