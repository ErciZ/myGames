using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using FairyGUI;

public class Inventory : MonoBehaviour {
    
    private GComponent _mainView;
    private GList _list;
    BagWindow _bagWindow;
    //protected Slot[] slotList;//这里建立一个数组,用来管理所有slot.
    Dictionary<Item, int> itemList = new Dictionary<Item, int>();//建立一个字典，key是物品，value是数量

    //玩家装备物品 武器  头 胸甲 腿 戒指
    //public int[] equiped_armor = new int[5] { 0, 0, 0, 0, 0 };
 //   public int[] equiped_armor = new int[5] { 31001, 40001 , 40002, 40003, 40004 };
	//public List<equipments> equip_on = new List<equipments>();

	public static Inventory instance;

    public BagWindow bag;
    GameObject Weapon;
    GameObject Head;
    GameObject Chest;
    GameObject Leg;
    GameObject Ring;

    public EquipmentAttribute Weapon1;
    public EquipmentAttribute Head1;
    public EquipmentAttribute Chest1;
    public EquipmentAttribute Leg1;
    public EquipmentAttribute Ring1;


    public void Start () {
        Window win = new Window();
        win.contentPane = UIPackage.CreateObject("main", "BagWin").asCom;
        win.Center();
        win.modal = true;

        _list = win.contentPane.GetChild("list1").asList;
  
         Weapon = (GameObject)Instantiate(Resources.Load("Prefabs/Weapon"));  
         Head = (GameObject)Instantiate(Resources.Load("Prefabs/Head"));  
         Chest = (GameObject)Instantiate(Resources.Load("Prefabs/Chest"));  
         Leg = (GameObject)Instantiate(Resources.Load("Prefabs/Leg"));  
         Ring = (GameObject)Instantiate(Resources.Load("Prefabs/Ring"));  
        Weapon1 = GameObject.Find("Weapon(Clone)").GetComponent<EquipmentAttribute>();
        Head1 = GameObject.Find("Head(Clone)").GetComponent<EquipmentAttribute>();
        Chest1 = GameObject.Find("Chest(Clone)").GetComponent<EquipmentAttribute>();
        Leg1 = GameObject.Find("Leg(Clone)").GetComponent<EquipmentAttribute>();
        Ring1 = GameObject.Find("Ring(Clone)").GetComponent<EquipmentAttribute>();

	
	}

	private void Awake()
    {
		instance = this;

        
    }
    //遍历字典，显示所有物品到背包中
    public void showItemInBag(){
        foreach (KeyValuePair<Item, int> kvp in itemList)
        {
            int index = 0;
            GObject obj = _list.GetChildAt(index);

            ShowItem item = (ShowItem)obj;
            item.setIcon(index, kvp.Key.Sprite);
            item.setNumber(index, kvp.Value.ToString());

        }
    }


    public void changeItemNumber(int index,int newNumber){
        GObject obj = _list.GetChildAt(index);

        ShowItem item = (ShowItem)obj;
        item.setNumber(index,newNumber.ToString());


    }



    public void HasEquipAttribute(){
		for (int i = 0; i < 5;i++){
			HeroStatus.instance.AddStatus.HP += HeroStatus.instance.equip_on[i].HP;
			HeroStatus.instance.AddStatus.MP += HeroStatus.instance.equip_on[i].MP;

            HeroStatus.instance.AddStatus.S += HeroStatus.instance.equip_on[i].S;

            HeroStatus.instance.AddStatus.P += HeroStatus.instance.equip_on[i].P;

            HeroStatus.instance.AddStatus.D += HeroStatus.instance.equip_on[i].D;

            HeroStatus.instance.AddStatus.A += HeroStatus.instance.equip_on[i].A;

            HeroStatus.instance.AddStatus.I += HeroStatus.instance.equip_on[i].I;

            HeroStatus.instance.AddStatus.AtkValue += HeroStatus.instance.equip_on[i].AtkValue;

            HeroStatus.instance.AddStatus.DefValue += HeroStatus.instance.equip_on[i].DefValue;

            HeroStatus.instance.AddStatus.AValue += HeroStatus.instance.equip_on[i].AValue;

            HeroStatus.instance.AddStatus.MagicAtk += HeroStatus.instance.equip_on[i].MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += HeroStatus.instance.equip_on[i].MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += HeroStatus.instance.equip_on[i].AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += HeroStatus.instance.equip_on[i].Crit;

            HeroStatus.instance.AddStatus.CritDamage += HeroStatus.instance.equip_on[i].CritDamage;

            HeroStatus.instance.AddStatus.Hit += HeroStatus.instance.equip_on[i].Hit;

            HeroStatus.instance.AddStatus.Agl += HeroStatus.instance.equip_on[i].Agl;         

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += HeroStatus.instance.equip_on[i].HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += HeroStatus.instance.equip_on[i].MPRecoverPerSecond;
		}
		HeroStatus.instance.UpdateAttribute();

    }

    //本来身上的装备
    //IEnumerator HasEquiped()
    //{
    //    //Debug.Log("aaaaaa");
    //    for (int a = 0; a < 5; a = a + 1)
    //    {
    //        //Debug.Log(equiped_armor[a]);
    //        CloudManager.instance.getEquipmentStatus(equiped_armor[a]);
    //        yield return new WaitUntil(() => CloudManager.instance.isEnd == true);
    //        //yield return new WaitForSeconds  (0.5f); 
    //        //StartCoroutine(UpdateAddattribute_equip_E(equiped_armor[a]));
    //        //UpdateAddattribute_equip_E(equiped_armor[a]);
    //    }
    //    //Debug.Log("bbbbb");
    //    //string a = CloudManager.instance.getItemType(ID);
    //    //CloudManager.instance.getEquipmentStatus(ID);
    //    //Debug.Log(ID);
    //    //yield return new WaitUntil(() => CloudManager.instance.isFind == true);

    //    //yield return new WaitForSeconds  (2); 

    //    HasEquipAttribute();
    //    //Debug.Log(CloudManager.instance.type);
       
    //}


    IEnumerator UpdateAddattribute_equip_E(int ID)
    {
        //string a = CloudManager.instance.getItemType(ID);
        CloudManager.instance.getEquipmentStatus(ID);
        //Debug.Log(ID);
        //yield return new WaitUntil(() => CloudManager.instance.isFind == true);
        yield return new WaitUntil(() =>CloudManager.instance.isEnd==true);
        //Debug.Log(CloudManager.instance.type);

        Debug.Log(CloudManager.instance.type);
        if(CloudManager.instance.type=="Weapon"){
            HeroStatus.instance.AddStatus.HP += Weapon1.HP;
            //Debug.Log("equ获得属性？" + Weapon1.HP);
            //HeroStatus.instance.AddStatus.MP += Equipment;
            HeroStatus.instance.AddStatus.MP += Weapon1.MP;

            HeroStatus.instance.AddStatus.S += Weapon1.S;

            HeroStatus.instance.AddStatus.P += Weapon1.P;

            HeroStatus.instance.AddStatus.D += Weapon1.D;

            HeroStatus.instance.AddStatus.A += Weapon1.A;

            HeroStatus.instance.AddStatus.I += Weapon1.I;

            HeroStatus.instance.AddStatus.AtkValue += Weapon1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue += Weapon1.DefValue;

            HeroStatus.instance.AddStatus.AValue += Weapon1.AValue;

            HeroStatus.instance.AddStatus.IValue += Weapon1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk += Weapon1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += Weapon1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += Weapon1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += Weapon1.Crit;

            HeroStatus.instance.AddStatus.CritDamage += Weapon1.CritDamage;

            HeroStatus.instance.AddStatus.Hit += Weapon1.Hit;

            HeroStatus.instance.AddStatus.Agl += Weapon1.Agl;

            HeroStatus.instance.AddStatus.Counter += Weapon1.Counter;

            HeroStatus.instance.AddStatus.Double += Weapon1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += Weapon1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += Weapon1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Head")
        {
            HeroStatus.instance.AddStatus.HP += Head1.HP;
            //Debug.Log("equ获得属性？" + Head1.HP);
            //HeroStatus.instance.AddStatus.MP += Equipment;
            HeroStatus.instance.AddStatus.MP += Head1.MP;

            HeroStatus.instance.AddStatus.S += Head1.S;

            HeroStatus.instance.AddStatus.P += Head1.P;

            HeroStatus.instance.AddStatus.D += Head1.D;

            HeroStatus.instance.AddStatus.A += Head1.A;

            HeroStatus.instance.AddStatus.I += Head1.I;

            HeroStatus.instance.AddStatus.AtkValue += Head1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue += Head1.DefValue;

            HeroStatus.instance.AddStatus.AValue += Head1.AValue;

            HeroStatus.instance.AddStatus.IValue += Head1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk += Head1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += Head1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += Head1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += Head1.Crit;

            HeroStatus.instance.AddStatus.CritDamage += Head1.CritDamage;

            HeroStatus.instance.AddStatus.Hit += Head1.Hit;

            HeroStatus.instance.AddStatus.Agl += Head1.Agl;

            HeroStatus.instance.AddStatus.Counter += Head1.Counter;

            HeroStatus.instance.AddStatus.Double += Head1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += Head1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += Head1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Chest")
        {
            HeroStatus.instance.AddStatus.HP += Chest1.HP;
            //Debug.Log("equ获得属性？" + Chest1.HP);
            //HeroStatus.instance.AddStatus.MP += Equipment;
            HeroStatus.instance.AddStatus.MP += Chest1.MP;

            HeroStatus.instance.AddStatus.S += Chest1.S;

            HeroStatus.instance.AddStatus.P += Chest1.P;

            HeroStatus.instance.AddStatus.D += Chest1.D;

            HeroStatus.instance.AddStatus.A += Chest1.A;

            HeroStatus.instance.AddStatus.I += Chest1.I;

            HeroStatus.instance.AddStatus.AtkValue += Chest1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue += Chest1.DefValue;

            HeroStatus.instance.AddStatus.AValue += Chest1.AValue;

            HeroStatus.instance.AddStatus.IValue += Chest1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk += Chest1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += Chest1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += Chest1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += Chest1.Crit;

            HeroStatus.instance.AddStatus.CritDamage += Chest1.CritDamage;

            HeroStatus.instance.AddStatus.Hit += Chest1.Hit;

            HeroStatus.instance.AddStatus.Agl += Chest1.Agl;

            HeroStatus.instance.AddStatus.Counter += Chest1.Counter;

            HeroStatus.instance.AddStatus.Double += Chest1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += Chest1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += Chest1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Leg")
        {
            HeroStatus.instance.AddStatus.HP += Leg1.HP;
            //Debug.Log("equ获得属性？" + Leg1.HP);
            //HeroStatus.instance.AddStatus.MP += Equipment;
            HeroStatus.instance.AddStatus.MP += Leg1.MP;

            HeroStatus.instance.AddStatus.S += Leg1.S;

            HeroStatus.instance.AddStatus.P += Leg1.P;

            HeroStatus.instance.AddStatus.D += Leg1.D;

            HeroStatus.instance.AddStatus.A += Leg1.A;

            HeroStatus.instance.AddStatus.I += Leg1.I;

            HeroStatus.instance.AddStatus.AtkValue += Leg1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue += Leg1.DefValue;

            HeroStatus.instance.AddStatus.AValue += Leg1.AValue;

            HeroStatus.instance.AddStatus.IValue += Leg1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk += Leg1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += Leg1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += Leg1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += Leg1.Crit;

            HeroStatus.instance.AddStatus.CritDamage += Leg1.CritDamage;

            HeroStatus.instance.AddStatus.Hit += Leg1.Hit;

            HeroStatus.instance.AddStatus.Agl += Leg1.Agl;

            HeroStatus.instance.AddStatus.Counter += Leg1.Counter;

            HeroStatus.instance.AddStatus.Double += Leg1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += Leg1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += Leg1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Ring")
        {
            HeroStatus.instance.AddStatus.HP += Ring1.HP;
            //Debug.Log("equ获得属性？" + Ring1.HP);
            //HeroStatus.instance.AddStatus.MP += Equipment;
            HeroStatus.instance.AddStatus.MP += Ring1.MP;

            HeroStatus.instance.AddStatus.S += Ring1.S;

            HeroStatus.instance.AddStatus.P += Ring1.P;

            HeroStatus.instance.AddStatus.D += Ring1.D;

            HeroStatus.instance.AddStatus.A += Ring1.A;

            HeroStatus.instance.AddStatus.I += Ring1.I;

            HeroStatus.instance.AddStatus.AtkValue += Ring1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue += Ring1.DefValue;

            HeroStatus.instance.AddStatus.AValue += Ring1.AValue;

            HeroStatus.instance.AddStatus.IValue += Ring1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk += Ring1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef += Ring1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed += Ring1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit += Ring1.Crit;

            HeroStatus.instance.AddStatus.CritDamage += Ring1.CritDamage;

            HeroStatus.instance.AddStatus.Hit += Ring1.Hit;

            HeroStatus.instance.AddStatus.Agl += Ring1.Agl;

            HeroStatus.instance.AddStatus.Counter += Ring1.Counter;

            HeroStatus.instance.AddStatus.Double += Ring1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond += Ring1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond += Ring1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }



    }

    //IEnumerator UpdateAddattribute_equip_E(int ID)
    //{
    //    CloudManager.instance.getEquipmentStatus(ID);
    //    //Debug.Log("111111");
    //    yield return new WaitUntil(() =>CloudManager.instance.isEnd==true);
    //    //Debug.Log("22222222");
    //    HeroStatus.instance.AddStatus.HP += Equipment.Instance.HP;
    //        //Debug.Log("equ获得属性？" + Equipment.Instance.HP);

    //    Debug.Log(Equipment.Instance.Name);
    //    Debug.Log("add获得属性？" + Weapon1.HP);


    //        //HeroStatus.instance.AddStatus.MP += Equipment;
    //        HeroStatus.instance.AddStatus.MP += Equipment.Instance.MP;

    //        HeroStatus.instance.AddStatus.S += Equipment.Instance.S;

    //        HeroStatus.instance.AddStatus.P += Equipment.Instance.P;

    //        HeroStatus.instance.AddStatus.D += Equipment.Instance.D;

    //        HeroStatus.instance.AddStatus.A += Equipment.Instance.A;

    //        HeroStatus.instance.AddStatus.I += Equipment.Instance.I;

    //        HeroStatus.instance.AddStatus.AtkValue += Equipment.Instance.AtkValue;

    //        HeroStatus.instance.AddStatus.DefValue += Equipment.Instance.DefValue;

    //        HeroStatus.instance.AddStatus.AValue += Equipment.Instance.AValue;

    //        HeroStatus.instance.AddStatus.IValue += Equipment.Instance.IValue;

    //        HeroStatus.instance.AddStatus.MagicAtk += Equipment.Instance.MagicAtk;

    //        HeroStatus.instance.AddStatus.MagicDef += Equipment.Instance.MagicDef;

    //        HeroStatus.instance.AddStatus.AttackSpeed += Equipment.Instance.AttackSpeed;

    //        HeroStatus.instance.AddStatus.Crit += Equipment.Instance.Crit;

    //        HeroStatus.instance.AddStatus.CritDamage += Equipment.Instance.CritDamage;

    //        HeroStatus.instance.AddStatus.Hit += Equipment.Instance.Hit; 

    //        HeroStatus.instance.AddStatus.Agl += Equipment.Instance.Agl;

    //        HeroStatus.instance.AddStatus.Counter += Equipment.Instance.Counter;

    //        HeroStatus.instance.AddStatus.Double += Equipment.Instance.Double;

    //        HeroStatus.instance.AddStatus.HPRecoverPerSecond += Equipment.Instance.HPRecoverPerSecond;

    //        HeroStatus.instance.AddStatus.MPRecoverPerSecond += Equipment.Instance.MPRecoverPerSecond;
    //        HeroStatus.instance.UpdateAttribute();
     
    //}

    //public void increaseAttribute(){
    //    HeroStatus.instance.AddStatus.HP += Equipment.Instance.HP;
    //        Debug.Log("equ获得属性？" + Equipment.Instance.HP);
    //        Debug.Log("add获得属性？" + HeroStatus.instance.AddStatus.HP);


    //        //HeroStatus.instance.AddStatus.MP += Equipment;
    //        HeroStatus.instance.AddStatus.MP += Equipment.Instance.MP;

    //        HeroStatus.instance.AddStatus.S += Equipment.Instance.S;

    //        HeroStatus.instance.AddStatus.P += Equipment.Instance.P;

    //        HeroStatus.instance.AddStatus.D += Equipment.Instance.D;

    //        HeroStatus.instance.AddStatus.A += Equipment.Instance.A;

    //        HeroStatus.instance.AddStatus.I += Equipment.Instance.I;

    //        HeroStatus.instance.AddStatus.AtkValue += Equipment.Instance.AtkValue;

    //        HeroStatus.instance.AddStatus.DefValue += Equipment.Instance.DefValue;

    //        HeroStatus.instance.AddStatus.AValue += Equipment.Instance.AValue;

    //        HeroStatus.instance.AddStatus.IValue += Equipment.Instance.IValue;

    //        HeroStatus.instance.AddStatus.MagicAtk += Equipment.Instance.MagicAtk;

    //        HeroStatus.instance.AddStatus.MagicDef += Equipment.Instance.MagicDef;

    //        HeroStatus.instance.AddStatus.AttackSpeed += Equipment.Instance.AttackSpeed;

    //        HeroStatus.instance.AddStatus.Crit += Equipment.Instance.Crit;

    //        HeroStatus.instance.AddStatus.CritDamage += Equipment.Instance.CritDamage;

    //        HeroStatus.instance.AddStatus.Hit += Equipment.Instance.Hit;

    //        HeroStatus.instance.AddStatus.Agl += Equipment.Instance.Agl;

    //        HeroStatus.instance.AddStatus.Counter += Equipment.Instance.Counter;

    //        HeroStatus.instance.AddStatus.Double += Equipment.Instance.Double;

    //        HeroStatus.instance.AddStatus.HPRecoverPerSecond += Equipment.Instance.HPRecoverPerSecond;

    //        HeroStatus.instance.AddStatus.MPRecoverPerSecond += Equipment.Instance.MPRecoverPerSecond;
     
        
    //}

    //private void UpdateAddattribute_equip_E(int ID)
    //{

    //    CloudManager.instance.getEquipmentStatus(ID);

       
    //}

    IEnumerator UpdateAddattribute_unequip_E(int ID)
    {
        //string a = CloudManager.instance.getItemType(ID);
        CloudManager.instance.getEquipmentStatus(ID);
        //Debug.Log(ID);
        //yield return new WaitUntil(() => CloudManager.instance.isFind == true);
        yield return new WaitUntil(() => CloudManager.instance.isEnd == true);
        //Debug.Log(CloudManager.instance.type);

        Debug.Log(CloudManager.instance.type);
        if (CloudManager.instance.type == "Weapon")
        {
            HeroStatus.instance.AddStatus.HP -= Weapon1.HP;
            //Debug.Log("equ获得属性？" + Weapon1.HP);
            //HeroStatus.instance.AddStatus.MP -= Equipment;
            HeroStatus.instance.AddStatus.MP -= Weapon1.MP;

            HeroStatus.instance.AddStatus.S -= Weapon1.S;

            HeroStatus.instance.AddStatus.P -= Weapon1.P;

            HeroStatus.instance.AddStatus.D -= Weapon1.D;

            HeroStatus.instance.AddStatus.A -= Weapon1.A;

            HeroStatus.instance.AddStatus.I -= Weapon1.I;

            HeroStatus.instance.AddStatus.AtkValue -= Weapon1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue -= Weapon1.DefValue;

            HeroStatus.instance.AddStatus.AValue -= Weapon1.AValue;

            HeroStatus.instance.AddStatus.IValue -= Weapon1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk -= Weapon1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef -= Weapon1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed -= Weapon1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit -= Weapon1.Crit;

            HeroStatus.instance.AddStatus.CritDamage -= Weapon1.CritDamage;

            HeroStatus.instance.AddStatus.Hit -= Weapon1.Hit;

            HeroStatus.instance.AddStatus.Agl -= Weapon1.Agl;

            HeroStatus.instance.AddStatus.Counter -= Weapon1.Counter;

            HeroStatus.instance.AddStatus.Double -= Weapon1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond -= Weapon1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond -= Weapon1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Head")
        {
            HeroStatus.instance.AddStatus.HP -= Head1.HP;
            //Debug.Log("equ获得属性？" + Head1.HP);
            //HeroStatus.instance.AddStatus.MP -= Equipment;
            HeroStatus.instance.AddStatus.MP -= Head1.MP;

            HeroStatus.instance.AddStatus.S -= Head1.S;

            HeroStatus.instance.AddStatus.P -= Head1.P;

            HeroStatus.instance.AddStatus.D -= Head1.D;

            HeroStatus.instance.AddStatus.A -= Head1.A;

            HeroStatus.instance.AddStatus.I -= Head1.I;

            HeroStatus.instance.AddStatus.AtkValue -= Head1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue -= Head1.DefValue;

            HeroStatus.instance.AddStatus.AValue -= Head1.AValue;

            HeroStatus.instance.AddStatus.IValue -= Head1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk -= Head1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef -= Head1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed -= Head1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit -= Head1.Crit;

            HeroStatus.instance.AddStatus.CritDamage -= Head1.CritDamage;

            HeroStatus.instance.AddStatus.Hit -= Head1.Hit;

            HeroStatus.instance.AddStatus.Agl -= Head1.Agl;

            HeroStatus.instance.AddStatus.Counter -= Head1.Counter;

            HeroStatus.instance.AddStatus.Double -= Head1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond -= Head1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond -= Head1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Chest")
        {
            HeroStatus.instance.AddStatus.HP -= Chest1.HP;
            //Debug.Log("equ获得属性？" + Chest1.HP);
            //HeroStatus.instance.AddStatus.MP -= Equipment;
            HeroStatus.instance.AddStatus.MP -= Chest1.MP;

            HeroStatus.instance.AddStatus.S -= Chest1.S;

            HeroStatus.instance.AddStatus.P -= Chest1.P;

            HeroStatus.instance.AddStatus.D -= Chest1.D;

            HeroStatus.instance.AddStatus.A -= Chest1.A;

            HeroStatus.instance.AddStatus.I -= Chest1.I;

            HeroStatus.instance.AddStatus.AtkValue -= Chest1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue -= Chest1.DefValue;

            HeroStatus.instance.AddStatus.AValue -= Chest1.AValue;

            HeroStatus.instance.AddStatus.IValue -= Chest1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk -= Chest1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef -= Chest1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed -= Chest1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit -= Chest1.Crit;

            HeroStatus.instance.AddStatus.CritDamage -= Chest1.CritDamage;

            HeroStatus.instance.AddStatus.Hit -= Chest1.Hit;

            HeroStatus.instance.AddStatus.Agl -= Chest1.Agl;

            HeroStatus.instance.AddStatus.Counter -= Chest1.Counter;

            HeroStatus.instance.AddStatus.Double -= Chest1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond -= Chest1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond -= Chest1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Leg")
        {
            HeroStatus.instance.AddStatus.HP -= Leg1.HP;
            //Debug.Log("equ获得属性？" + Leg1.HP);
            //HeroStatus.instance.AddStatus.MP -= Equipment;
            HeroStatus.instance.AddStatus.MP -= Leg1.MP;

            HeroStatus.instance.AddStatus.S -= Leg1.S;

            HeroStatus.instance.AddStatus.P -= Leg1.P;

            HeroStatus.instance.AddStatus.D -= Leg1.D;

            HeroStatus.instance.AddStatus.A -= Leg1.A;

            HeroStatus.instance.AddStatus.I -= Leg1.I;

            HeroStatus.instance.AddStatus.AtkValue -= Leg1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue -= Leg1.DefValue;

            HeroStatus.instance.AddStatus.AValue -= Leg1.AValue;

            HeroStatus.instance.AddStatus.IValue -= Leg1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk -= Leg1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef -= Leg1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed -= Leg1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit -= Leg1.Crit;

            HeroStatus.instance.AddStatus.CritDamage -= Leg1.CritDamage;

            HeroStatus.instance.AddStatus.Hit -= Leg1.Hit;

            HeroStatus.instance.AddStatus.Agl -= Leg1.Agl;

            HeroStatus.instance.AddStatus.Counter -= Leg1.Counter;

            HeroStatus.instance.AddStatus.Double -= Leg1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond -= Leg1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond -= Leg1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }
        else if (CloudManager.instance.type == "Ring")
        {
            HeroStatus.instance.AddStatus.HP -= Ring1.HP;
            //Debug.Log("equ获得属性？" + Ring1.HP);
            //HeroStatus.instance.AddStatus.MP -= Equipment;
            HeroStatus.instance.AddStatus.MP -= Ring1.MP;

            HeroStatus.instance.AddStatus.S -= Ring1.S;

            HeroStatus.instance.AddStatus.P -= Ring1.P;

            HeroStatus.instance.AddStatus.D -= Ring1.D;

            HeroStatus.instance.AddStatus.A -= Ring1.A;

            HeroStatus.instance.AddStatus.I -= Ring1.I;

            HeroStatus.instance.AddStatus.AtkValue -= Ring1.AtkValue;

            HeroStatus.instance.AddStatus.DefValue -= Ring1.DefValue;

            HeroStatus.instance.AddStatus.AValue -= Ring1.AValue;

            HeroStatus.instance.AddStatus.IValue -= Ring1.IValue;

            HeroStatus.instance.AddStatus.MagicAtk -= Ring1.MagicAtk;

            HeroStatus.instance.AddStatus.MagicDef -= Ring1.MagicDef;

            HeroStatus.instance.AddStatus.AttackSpeed -= Ring1.AttackSpeed;

            HeroStatus.instance.AddStatus.Crit -= Ring1.Crit;

            HeroStatus.instance.AddStatus.CritDamage -= Ring1.CritDamage;

            HeroStatus.instance.AddStatus.Hit -= Ring1.Hit;

            HeroStatus.instance.AddStatus.Agl -= Ring1.Agl;

            HeroStatus.instance.AddStatus.Counter -= Ring1.Counter;

            HeroStatus.instance.AddStatus.Double -= Ring1.Double;

            HeroStatus.instance.AddStatus.HPRecoverPerSecond -= Ring1.HPRecoverPerSecond;

            HeroStatus.instance.AddStatus.MPRecoverPerSecond -= Ring1.MPRecoverPerSecond;
            HeroStatus.instance.UpdateAttribute();
        }

    }
    //玩家装备物品 武器  头 胸甲 腿 戒指
    //public void equipItem(Equipment item)
    //{ 
    //    if(item.EquipType == "Head"){
    //        if (equiped_armor[1]==0){
    //            equiped_armor[1] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //        else{
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[1]));
    //            equiped_armor[1] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //    }
    //    else if (item.EquipType == "Weapon")
    //    {
    //        if (equiped_armor[0] == 0)
    //        {
    //            equiped_armor[0] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //        else
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[0]));
    //            equiped_armor[0] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //    }
    //    else if (item.EquipType == "Chest"){
    //        if (equiped_armor[2] == 0)
    //        {
    //            equiped_armor[2] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //        else
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[2]));
    //            equiped_armor[2] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //    }
    //    else if (item.EquipType == "Leg")
    //    {
    //        if (equiped_armor[3] == 0)
    //        {
    //            equiped_armor[3] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //        else
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[3]));
    //            equiped_armor[3] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //    }
    //    else if (item.EquipType == "Ring")
    //    {
    //        if (equiped_armor[4] == 0)
    //        {
    //            equiped_armor[4] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //        else
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[4]));
    //            equiped_armor[4] = item.ID;
    //            StartCoroutine(UpdateAddattribute_equip_E(item.ID));
    //            //UpdateAddattribute_equip_E(item.ID);
    //        }
    //    }
    //    else 
    //    {

    //    }

    //}


    //public void unequipItem(Equipment item)
    //{
    //    bool inList = false;
    //    foreach(int a in equiped_armor){
    //        if(a==item.ID){
    //            inList = true;
    //        }
    //    }
    //    if (inList==true)
    //    {


    //        if (item.EquipType == "Head")
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[1]));
    //            //UpdateAddattribute_unequip_E(equiped_armor[0]);
    //            equiped_armor[0] = 0;

    //        }
    //        else if (item.EquipType == "Weapon")
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[0]));
    //            equiped_armor[1] = 0;
    //        }
    //        else if (item.EquipType == "Chest")
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[2]));
    //            equiped_armor[2] = 0;
    //        }
    //        else if (item.EquipType == "Leg")
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[3]));
    //            equiped_armor[3] = 0;
    //        }
    //        else if (item.EquipType == "Ring")
    //        {
    //            StartCoroutine(UpdateAddattribute_unequip_E(equiped_armor[4]));
    //            equiped_armor[4] = 0;
    //        }
    //    }
    //    else{
    //        Debug.Log("你没有装备这个道具");
    //    }
    //}

    public void useItem()
    {

    }

    public void dropItem(){
        
    }



    //void Update()
    //{
    //    if (canvasGroup.alpha != targetAlpha)
    //    {
    //        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
    //        if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < .01f)
    //        {
    //            canvasGroup.alpha = targetAlpha;
    //        }
    //    }
    //}

    //public bool StoreItem(int id)
    //{
    //    Item item = InventoryManager.Instance.GetItemById(id);
    //    return StoreItem(item);
    //}
    //public bool StoreItem(Item item)//存储Item核心代码
    //{
    //    if (item == null)//如果物品不存在直接报错并且返回false
    //    {
    //        Debug.LogWarning("要存储的物品的id不存在");
    //        return false;
    //    }
    //    if (item.Capacity == 1)//容量上限为1
    //    {
    //        Slot slot = FindEmptySlot();//得到返回的solt
    //        if (slot == null)//如果得到的物品槽是空,输出没有得到物品
    //        {
    //            Debug.LogWarning("没有空的物品槽");
    //            return false;
    //        }
    //        else//如果得到的物品槽不是空,调用Slot里面的存储方法
    //        {
    //            slot.StoreItem(item);//把物品存储到这个空的物品槽里面

    //        }
    //    }
    //    else//容量上限大于1
    //    {
    //        Slot slot = FindSameIdSlot(item);
    //        if (slot != null)
    //        {
    //            slot.StoreItem(item);
    //        }
    //        else
    //        {
    //            Slot emptySlot = FindEmptySlot();//得到返回的solt
    //            if (emptySlot != null)//如果得到的物品槽不是空,调用Slot里面的存储方法.
                    
    //            {
    //                emptySlot.StoreItem(item);
    //            }
    //            else //如果得到的物品槽是空,输出没有得到物品
    //            {
    //                Debug.LogWarning("没有空的物品槽");
    //                return false;
    //            }
    //        }
    //    }
    //    return true;
    //}



    ////public Item GetItemById(int id)//通过Id返回一个Item.返回值是Item
    ////{
    ////    foreach (Item item in itemList)//遍历当前物品类型
    ////    {
    ////        if (item.ID == id)//如果有任何一个物品的Id和现在的对比的id一样,返回该物品
    ////        {
    ////            return item;
    ////        }
    ////    }
    ////    return null;//如果没有相同的id,返回空
    ////}

    //private Slot FindSameIdSlot(Item item)//创建一个寻找相同Id的的物品槽,并返回物品槽
    //{
    //    foreach (Slot slot in slotList)
    //    {
    //        if (slot.transform.childCount >= 1 && slot.GetItemId() == item.ID &&slot.IsFilled()==false )
    //        {
    //            return slot;
    //        }
    //    }
    //    return null;
    //}

    //public void Show()
    //{
    //    canvasGroup.blocksRaycasts = true;
    //    targetAlpha = 1;
    //}
    //public void Hide()
    //{
    //    canvasGroup.blocksRaycasts = false;
    //    targetAlpha = 0;
    //}
    //public void DisplaySwitch()
    //{
    //    if (targetAlpha == 0)
    //    {
    //        Show();
    //    }
    //    else
    //    {
    //        Hide();
    //    }
    //}

    //#region save and load
    //public void SaveInventory()
    //{
    //    StringBuilder sb = new StringBuilder();
    //    foreach (Slot slot in slotList)
    //    {
    //        if (slot.transform.childCount > 0)
    //        {
    //            ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
    //            sb.Append(itemUI.Item.ID + ","+itemUI.Amount+"-");
    //        }
    //        else
    //        {
    //            sb.Append("0-");
    //        }
    //    }
    //    PlayerPrefs.SetString(this.gameObject.name, sb.ToString());
    //}
    //public void LoadInventory()
    //{
    //    if (PlayerPrefs.HasKey(this.gameObject.name) == false) return;
    //    string str = PlayerPrefs.GetString(this.gameObject.name);
    //    //print(str);
    //    string[] itemArray = str.Split('-');
    //    for (int i = 0; i < itemArray.Length-1; i++)
    //    {
    //        string itemStr = itemArray[i];
    //        if (itemStr != "0")
    //        {
    //            //print(itemStr);
    //            string[] temp = itemStr.Split(',');
    //            int id = int.Parse(temp[0]);
    //            Item item = InventoryManager.Instance.GetItemById(id);
    //            int amount = int.Parse(temp[1]);
    //            for (int j = 0; j < amount; j++)
    //            {
    //                slotList[i].StoreItem(item);
    //            }
    //        }
    //    }
    //}
    //#endregion
}
