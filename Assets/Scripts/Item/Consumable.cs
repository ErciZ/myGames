using UnityEngine;
using System.Collections;
/// <summary>
/// 消耗品类
/// </summary>
public class Consumable : Item {

    public int HP { get; set; }
    public int MP { get; set; }

    public Consumable(int id, string name, string type, string quality, string des, int capacity, int buyPrice, int sellPrice ,string sprite,int hp,int mp)
        :base(id,name,type,quality,des,capacity,buyPrice,sellPrice,sprite)
    {
        this.HP = hp;
        this.MP = mp;
    }

    //public override string GetToolTipText()//重写父类的GetToolTipText
    //{
    //    string text = base.GetToolTipText();;//得到基于父类的文本信息

    //    string newText = string.Format("{0}\n\n<color=blue>加血：{1}\n加蓝：{2}</color>", text, HP, MP);

    //    return newText;
    //}

    public override string ToString()
    {
        string s = "";
        s += ID.ToString();
        s += Type;
        s += Quality;
        s += Description;
        s += Capacity; 
        s += BuyPrice;
        s += SellPrice;
        s += Sprite;
        s += HP;
        s += MP;
        return s;
    }

    /// <summary>  
    /// 拷贝构造函数  
    /// </summary>  
    /// <param name="item">待拷贝的属性</param>  
    /// 本身构造  
    /// <param name="hp">HP</param>  
    /// <param name="mp">MP</param>  
    public Consumable(Item item, int hp, int mp)
    {
        this.ID = item.ID;
        this.Name = item.Name;
        this.Type = item.Type;
        this.Quality = item.Quality;
        this.Description = item.Description;
        this.Capacity = item.Capacity;
        this.BuyPrice = item.BuyPrice;
        this.SellPrice = item.SellPrice;
        this.Sprite = item.Sprite;

        this.HP = hp;
        this.MP = mp;
    }

}
