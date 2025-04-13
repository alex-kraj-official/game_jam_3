using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.Serialization;

public class Shop : MonoBehaviour
{
    public ResourceManager resourceManager;

    //input fields
    public TextMeshProUGUI amountInputSheep;
    public TextMeshProUGUI amountInputWood;
    public TextMeshProUGUI amountInputOre;
    public TextMeshProUGUI amountInputWheat;
    //sell and buy prices
    public float woodSellPrice;
    public float woodBuyPrice;

    public float sheepSellPrice;
    public float sheepBuyPrice;

    public float wheatSellPrice;
    public float wheatBuyPrice;

    public float oreSellPrice;
    public float oreBuyPrice;

    //
    public float sheepAmount;
    public float wheatAmount;
    public float oreAmount;
    public float woodAmount;

    public void increaseAmountSheep(float amount)
    {
        sheepAmount = sheepAmount + 10;
        amountInputSheep.SetText(sheepAmount.ToString());
    }
    public void decreaseAmountSheep(float amount)
    {
        sheepAmount = sheepAmount - 10;
        amountInputSheep.SetText(sheepAmount.ToString());
    }
    public void increaseAmountWheat(float amount)
    {
        wheatAmount = wheatAmount + 10;
        amountInputWheat.SetText(wheatAmount.ToString());
    }
    public void decreaseAmountWheat(float amount)
    {
        wheatAmount = wheatAmount - 10;
        amountInputWheat.SetText(wheatAmount.ToString());
    }
    public void increaseAmountOre(float amount)
    {
        oreAmount = oreAmount + 10;
        amountInputOre.SetText(oreAmount.ToString());
    }
    public void decreaseAmountOre(float amount)
    {
        oreAmount = oreAmount - 10;
        amountInputOre.SetText(oreAmount.ToString());
    }
    public void increaseAmountWood(float amount)
    {
        woodAmount = woodAmount + 10;
        amountInputWood.SetText(woodAmount.ToString());
    }
    public void decreaseAmountWood(float amount)
    {
        woodAmount = woodAmount - 10;
        amountInputWood.SetText(woodAmount.ToString());
    }
    public void sellSheep(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.removeSheep(amount);
            resourceManager.getGold(amount*sheepSellPrice);
        }
    }
    public void buySheep(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.getSheep(amount);
            resourceManager.removeGold(amount * sheepSellPrice);
        }
    }
    public void sellWood(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.removeWood(amount);
            resourceManager.getGold(amount * woodSellPrice);
        }
    }
    public void buyWood(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.getWood(amount);
            resourceManager.removeGold(amount * woodSellPrice);
        }
    }
    public void sellWheat(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.removeWheat(amount);
            resourceManager.getGold(amount * wheatSellPrice);
        }
    }
    public void buyWheat(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.getWheat(amount);
            resourceManager.removeGold(amount * wheatSellPrice);
        }
    }
    public void sellOre(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.removeOre(amount);
            resourceManager.getGold(amount * oreSellPrice);
        }
    }
    public void buyOre(float amount)
    {
        if (resourceManager != null)
        {
            resourceManager.getOre(amount);
            resourceManager.removeGold(amount * oreSellPrice);
        }
    }

}
