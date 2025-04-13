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

    private void Start()
    {
        amountInputSheep.SetText("0");
        amountInputWood.SetText("0");
        amountInputOre.SetText("0");
        amountInputWheat.SetText("0");
    }

    public void increaseAmountSheep(float amount)
    {
        if (sheepAmount < 500)
        {
            sheepAmount = sheepAmount + 10;
            amountInputSheep.SetText(sheepAmount.ToString());
        }
    }
    public void decreaseAmountSheep(float amount)
    {
        if (sheepAmount > 0)
        {
            sheepAmount = sheepAmount - 10;
            amountInputSheep.SetText(sheepAmount.ToString());
        }
    }
    public void increaseAmountWheat(float amount)
    {
        if (wheatAmount < 500)
        {
            wheatAmount = wheatAmount + 10;
            amountInputWheat.SetText(wheatAmount.ToString());
        }
    }
    public void decreaseAmountWheat(float amount)
    {
        if (wheatAmount > 0)
        {
            wheatAmount = wheatAmount - 10;
            amountInputWheat.SetText(wheatAmount.ToString());
        }
    }
    public void increaseAmountOre(float amount)
    {
        if (oreAmount < 500)
        {
            oreAmount = oreAmount + 10;
            amountInputOre.SetText(oreAmount.ToString());
        }
    }
    public void decreaseAmountOre(float amount)
    {
        if (oreAmount > 0)
        {
            oreAmount = oreAmount - 10;
            amountInputOre.SetText(oreAmount.ToString());
        }
    }
    public void increaseAmountWood(float amount)
    {
        if (woodAmount < 500)
        {
            woodAmount = woodAmount + 10;
            amountInputWood.SetText(woodAmount.ToString());
        }
    }
    public void decreaseAmountWood(float amount)
    {
        if (woodAmount > 0)
        {
            woodAmount = woodAmount - 10;
            amountInputWood.SetText(woodAmount.ToString());
        }
    }
    public void sellSheep(float amount)
    {
        amount = sheepAmount;
        if (resourceManager != null && resourceManager.sheep >= amount)
        {
            resourceManager.removeSheep(amount);
            resourceManager.getGold(amount*sheepSellPrice);
        }
    }
    public void buySheep(float amount)
    {
        amount = sheepAmount;
        if (resourceManager != null)
        {
            resourceManager.getSheep(amount);
            resourceManager.removeGold(amount * sheepSellPrice);
        }
    }
    public void sellWood(float amount)
    {
        amount = woodAmount;
        if (resourceManager != null && resourceManager.wood >= amount)
        {
            resourceManager.removeWood(amount);
            resourceManager.getGold(amount * woodSellPrice);
        }
    }
    public void buyWood(float amount)
    {
        amount = woodAmount;
        if (resourceManager != null)
        {
            resourceManager.getWood(amount);
            resourceManager.removeGold(amount * woodSellPrice);
        }
    }
    public void sellWheat(float amount)
    {
        amount = wheatAmount;
        if (resourceManager != null && resourceManager.wheat >= amount)
        {
            resourceManager.removeWheat(amount);
            resourceManager.getGold(amount * wheatSellPrice);
        }
    }
    public void buyWheat(float amount)
    {
        amount = wheatAmount;
        if (resourceManager != null)
        {
            resourceManager.getWheat(amount);
            resourceManager.removeGold(amount * wheatSellPrice);
        }
    }
    public void sellOre(float amount)
    {
        amount = oreAmount;
        if (resourceManager != null && resourceManager.ore >= amount)
        {
            resourceManager.removeOre(amount);
            resourceManager.getGold(amount * oreSellPrice);
        }
    }
    public void buyOre(float amount)
    {
        amount = oreAmount;
        if (resourceManager != null)
        {
            resourceManager.getOre(amount);
            resourceManager.removeGold(amount * oreSellPrice);
        }
    }

}
