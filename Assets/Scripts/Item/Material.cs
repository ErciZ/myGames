using UnityEngine;
using System.Collections;

/// <summary>
/// 材料类
/// </summary>
public class theMaterial : Item {

    public theMaterial(int id, string name, string type, string quality, string des, int capacity, int buyPrice, int sellPrice,string sprite)
        : base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
    }


    /// <summary>  
    /// 拷贝构造函数  
    /// </summary>  
    /// <param name="item">待拷贝的属性</param>  
    public theMaterial(Item item)
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
    }
}
