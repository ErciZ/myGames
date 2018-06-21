using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class InventoryManager : MonoBehaviour
{

    #region 单例模式
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //下面的代码只会执行一次
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion
    
    /// <summary>
    ///  物品信息的列表（集合）
    /// </summary>
    private List<Item> itemList;








    void Awake()
    {
        //ParseItemJson();;//开始解析Json
    }

    void Start()
    { 
        //因为只有一个ToolTip类型,所以用FindObjectOfType来查找.
        //toolTip = GameObject.FindObjectOfType<ToolTip>();
        //canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        //pickedItem = GameObject.Find("PickedItem").GetComponent<ItemUI>();
        //通过ItemUI来控制PickedItem的状态.

       
    }

    void Update()
    {
        //if (isPickedItem)
        //{
        //    //如果我们捡起了物品，我们就要让物品跟随鼠标
        //    Vector2 position;
        //    //下面的函数用来得到鼠标的位置,并返回到position上.
        //    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        //    pickedItem.SetLocalPosition(position);
        //}else if (isToolTipShow)
        //{
        //    //控制提示面板跟随鼠标
        //    Vector2 position;
        //    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        //    toolTip.SetLocalPotion(position+toolTipPosionOffset);
        //}

        ////物品丢弃的处理
        //if (isPickedItem && Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1)==false)
        //{
        //    isPickedItem = false;
        //    PickedItem.Hide();
        //}
    }

    ///// <summary>
    ///// 解析物品信息
    ///// </summary>
    //void ParseItemJson()
    //{
    //    itemList = new List<Item>();
    //    //文本为在Unity里面是 TextAsset类型
    //    TextAsset itemText = Resources.Load<TextAsset>("Items");
    //    string itemsJson = itemText.text;//物品信息的Json格式
    //    JSONObject j = new JSONObject(itemsJson);
    //    foreach (JSONObject temp in j.list)//这里通过.list属性来获取j里面所有的对象,而不是直接访问j
    //    {
    //        //首先解析Type类型,因为物品是以这个分组存储的.
    //        //解析的方法是temp["xx"].str/n
    //        string typeStr = temp["type"].str;
    //        Item.ItemType type= (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);
    //        //通过System.Enum.Parse(type,value);来把一个对象转化成一个枚举类型
    //        //现在type就是一个枚举类型的数组了. 然后就可以用switch来处理了.
    //        //有很多公有的属性,可以放在外面,只把特殊的属性放在switch里面处理.

    //        //下面的事解析这个对象里面的公有属性
    //        int id = (int)(temp["id"].n);
    //        string name = temp["name"].str;
    //        Item.ItemQuality quality = (Item.ItemQuality)System.Enum.Parse(typeof(Item.ItemQuality), temp["quality"].str);
    //        string description = temp["description"].str;
    //        int capacity = (int)(temp["capacity"].n);
    //        int buyPrice = (int)(temp["buyPrice"].n);
    //        int sellPrice = (int)(temp["sellPrice"].n);
    //        string sprite = temp["sprite"].str;

    //        Item item = null; //在这里创建一个空的Item.对应每一个不同的类分别赋值
    //        switch (type)//特性类独有的属性在switch里面处理.
    //        {
    //            case Item.ItemType.Consumable: //Consumable特殊属性就是hp和mp
    //                int hp = (int)(temp["hp"].n);
    //                int mp = (int)(temp["mp"].n);
    //                //创建一个新的Consumable,注意这里是创建一个new Consumable,不是new Item
    //                item = new Consumable(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, hp, mp);
    //                break;
    //            case Item.ItemType.Equipment:
    //                //
    //                float  HP = (float)temp["HP"].n;
    //                float MP = (float)temp["MP"].n;
    //                float EP = (float)temp["EP"].n;
    //                float S = (float)temp["S"].n;
    //                float P = (float)temp["P"].n;
    //                float D = (float)temp["D"].n;
    //                float A = (float)temp["A"].n;
    //                float I = (float)temp["I"].n;
    //                float AtkValue = (float)temp["AtkValue"].n;
    //                float DefValue = (float)temp["DefValue"].n;
    //                float AValue = (float)temp["AValue"].n;
    //                float IValue = (float)temp["IValue"].n;
    //                float MagicAtk = (float)temp["MagicAtk"].n;
    //                float MagicDef = (float)temp["MagicDef"].n;
    //                float Comprehension = (float)temp["Comprehension"].n;
    //                float luck = (float)temp["luck"].n;
    //                float AttackSpeed = (float)temp["AttackSpeed"].n;
    //                float Exp = (float)temp["Exp"].n;
    //                float Crit = (float)temp["Crit"].n;
    //                float CritDamage = (float)temp["CritDamage"].n;
    //                float Hit = (float)temp["Hit"].n;
    //                float Agl = (float)temp["Agl"].n;
    //                float Double = (float)temp["Double"].n;
    //                float HPRecoverPerSecond = (float)temp["HPRecoverPerSecond"].n;
    //                float MPRecoverPerSecond = (float)temp["MPRecoverPerSecond"].n;
    //                int stamina = (int)temp["stamina"].n;
    //                float Counter = (float)temp["Counter"].n;


    //                Equipment.EquipmentType equipType = (Equipment.EquipmentType) System.Enum.Parse( typeof(Equipment.EquipmentType),temp["equipType"].str );
    //                item = new Equipment(id,  name,  type,  quality,  description,  capacity,  buyPrice,  sellPrice,  sprite,
    //                  HP,  MP,  EP,  S,  P,  D,  A,  I,  AtkValue,  DefValue,  AValue,  IValue,  MagicAtk,  MagicDef,  Comprehension,  luck,
    //                                     AttackSpeed,  Exp,  Crit,  CritDamage,  Hit,  Agl,  Counter,  Double,  HPRecoverPerSecond,  MPRecoverPerSecond,  stamina,  equipType,requiredS,requiredP,requiredD,requiredA,requiredI);
    //                break;
    //            case Item.ItemType.Weapon:
    //                float wHP = (float)temp["HP"].n;
    //                float wMP = (float)temp["MP"].n;
    //                float wEP = (float)temp["EP"].n;
    //                float wS = (float)temp["S"].n;
    //                float wP = (float)temp["P"].n;
    //                float wD = (float)temp["D"].n;
    //                float wA = (float)temp["A"].n;
    //                float wI = (float)temp["I"].n;
    //                float wAtkValue = (float)temp["AtkValue"].n;
    //                float wDefValue = (float)temp["DefValue"].n;
    //                float wAValue = (float)temp["AValue"].n;
    //                float wIValue = (float)temp["IValue"].n;
    //                float wMagicAtk = (float)temp["MagicAtk"].n;
    //                float wMagicDef = (float)temp["MagicDef"].n;
    //                float wComprehension = (float)temp["Comprehension"].n;
    //                float wluck = (float)temp["luck"].n;
    //                float wAttackSpeed = (float)temp["AttackSpeed"].n;
    //                float wExp = (float)temp["Exp"].n;
    //                float wCrit = (float)temp["Crit"].n;
    //                float wCritDamage = (float)temp["CritDamage"].n;
    //                float wHit = (float)temp["Hit"].n;
    //                float wAgl = (float)temp["Agl"].n;
    //                float wDouble = (float)temp["Double"].n;
    //                float wHPRecoverPerSecond = (float)temp["HPRecoverPerSecond"].n;
    //                float wMPRecoverPerSecond = (float)temp["MPRecoverPerSecond"].n;
    //                int wstamina = (int)temp["stamina"].n;
    //                float wCounter = (float)temp["Counter"].n;
    //                Weapon.WeaponType wpType = (Weapon.WeaponType)System.Enum.Parse(typeof(Weapon.WeaponType), temp["weaponType"].str);
    //                item = new Weapon(id,  name,  type,  quality,  description,  capacity,  buyPrice,  sellPrice,  sprite,
    //                  wHP,  wMP,  wEP,  wS,  wP,  wD,  wA,  wI,  wAtkValue,  wDefValue,  wAValue,  wIValue,  wMagicAtk,  wMagicDef,  wComprehension,  wluck,
    //                   wAttackSpeed,  wExp,  wCrit,  wCritDamage,  wHit,  wAgl,  wCounter,  wDouble,  wHPRecoverPerSecond,  wMPRecoverPerSecond,  wstamina,   wpType);
    //                break;
    //            case Item.ItemType.Material:
    //                //
    //                item = new theMaterial(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite);
    //                break;
    //        }
    //        //在创建完成这个物体之后把这个物体加入到列表中.
    //        itemList.Add(item);
    //        //Debug.Log(item);
    //    }
    //}

    //public Item GetItemById(int id)
    //{
    //    foreach (Item item in itemList)
    //    {
    //        if (item.ID == id)
    //        {
    //            return item;
    //        }
    //    }
    //    return null;
    //}






}