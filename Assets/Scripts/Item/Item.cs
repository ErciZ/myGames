using UnityEngine;
using System.Collections;

/// <summary>
/// 物品基类
/// </summary>
public class Item : MonoBehaviour {

    public int ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Quality { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; }


    public Item()
    {
        this.ID = -1;
    }

    public Item(int id, string name, string type, string quality, string des, int capacity, int buyPrice, int sellPrice,string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
        this.Description = des;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }

    public Item(Item item)
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


    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }
    /// <summary>
    /// 品质
    /// </summary>
    public enum ItemQuality
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Artifact
    }

    /// <summary> 
    /// 得到提示面板应该显示什么样的内容
    /// </summary>
    /// <returns></returns>
    ///  //返回物品的信息,这里用虚方法.这是因为这里是父类,子类不都一样,还会重写很多.
    //public virtual string GetToolTipText()
    //{
    //    string color = "";
    //    switch (Quality)
    //    {
    //        case ItemQuality.Common:
    //            color = "white";
    //            break;
    //        case ItemQuality.Uncommon:
    //            color = "lime";
    //            break;
    //        case ItemQuality.Rare:
    //            color = "navy";
    //            break;
    //        case ItemQuality.Epic:
    //            color = "magenta";
    //            break;
    //        case ItemQuality.Legendary:
    //            color = "orange";
    //            break;
    //        case ItemQuality.Artifact:
    //            color = "red";
    //            break;
    //    }
    //    string text = Description;
    //    return text;
    //}
}
