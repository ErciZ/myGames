using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading;
using FairyGUI;

public class PlayerData : MonoBehaviour
{

    private static PlayerData instance;
    public static PlayerData Instance
    {
        get
        {
            if (null == instance)
                instance = new PlayerData();
            return instance;
        }
        set { }
    }
    
	public Dictionary<int, int> itemList_e = new Dictionary<int, int>();//建立一个字典，key是物品，value是数量
	public Dictionary<DataType, int> itemListShow_e = new Dictionary<DataType, int>();//建立一个字典，key是物品，value是数量

	public Dictionary<int, int> itemList_c = new Dictionary<int, int>();//建立一个字典，key是物品，value是数量
    public Dictionary<DataType, int> itemListShow_c = new Dictionary<DataType, int>();//建立一个字典，key是物品，value是数量

	public Dictionary<int, int> itemList_m = new Dictionary<int, int>();//建立一个字典，key是物品，value是数量
    public Dictionary<DataType, int> itemListShow_m = new Dictionary<DataType, int>();//建立一个字典，key是物品，value是数量
   

    private int coinAmount = 100;
    private int diamond = 100;

    private Text coinText;

    public int CoinAmount
    {
        get
        {
            return coinAmount;
        }
        set
        {
            coinAmount = value;
            coinText.text = coinAmount.ToString();
        }
    }

    void Start()
    {
        coinText = GameObject.Find("Coin").GetComponentInChildren<Text>();
        coinText.text = coinAmount.ToString();
    }

    // Update is called once per frame
	void Update () {
	}

    /// <summary>
    /// 消费
    /// </summary>
    public bool ConsumeCoin(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 赚取金币
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        this.coinAmount += amount;
        coinText.text = coinAmount.ToString();
    }
}
