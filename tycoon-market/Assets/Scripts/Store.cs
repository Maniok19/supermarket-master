using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
   
   public float BaseStoreCost;
   public float BaseStoreProfit;
   public float StoreTimer;
   public int StoreCount;
    public bool ManagerUnlocked;
    public float StoreMultiplier;

    public Slider ProgressSlider;
    public gameManager GameManager;
  
    public Text StoreCountText;
    public Text StorePrice;
    private float NextStoreCost;
   

    
    float CurrentTimer = 0;
    bool StartTimer=false;
    // Start is called before the first frame update
    void Start()
    {
        StoreCountText.text = StoreCount.ToString();
        NextStoreCost = BaseStoreCost;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if (CurrentTimer > StoreTimer)
            {
                if(!ManagerUnlocked)
                         StartTimer = false;
                CurrentTimer = 0f;
                
                    GameManager.AddToBalance(BaseStoreProfit * StoreCount);
            }
            ProgressSlider.value = CurrentTimer / StoreTimer;
        }
    }
    public void BuyOnClick ()
    {
        if (!GameManager.CanBuy(NextStoreCost))
            return;
        StoreCount++;
     
        StoreCountText.text = StoreCount.ToString();
       
        GameManager.AddToBalance(-NextStoreCost);
        NextStoreCost = (BaseStoreCost * Mathf.Pow(StoreMultiplier, StoreCount));
        StorePrice.text = "Améliorer " + NextStoreCost.ToString("C2");
    }
    public void StoreOnClick()
    {
        if (!StartTimer & StoreCount>0)
        { StartTimer = true; }
    }
}
