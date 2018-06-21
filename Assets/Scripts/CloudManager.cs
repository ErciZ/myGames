using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeanCloud.Core;
using LeanCloud.Storage;
using LeanCloud.Utilities;
using Unity.Tasks;
using LeanCloud.Realtime;
using LeanCloud;
using System.Threading.Tasks;

public class CloudManager : MonoBehaviour
{
    public static CloudManager instance;

    //private EnemyStatus enemy;
    //private TurnControl turnScript; 

    public bool isEnd=false;
    public bool isFind = false;
    public EquipmentAttribute Weapon;
    public EquipmentAttribute Head;
    public EquipmentAttribute Chest;
    public EquipmentAttribute Leg;
    public EquipmentAttribute Ring;
    public string type;
 
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();
        //turnScript = GameObject.Find("TurnSystem").GetComponent<TurnControl>();
        Weapon = GameObject.Find("Weapon(Clone)").GetComponent<EquipmentAttribute>();
        Head = GameObject.Find("Head(Clone)").GetComponent<EquipmentAttribute>();
        Chest = GameObject.Find("Chest(Clone)").GetComponent<EquipmentAttribute>();
        Leg = GameObject.Find("Leg(Clone)").GetComponent<EquipmentAttribute>();
        Ring = GameObject.Find("Ring(Clone)").GetComponent<EquipmentAttribute>();
		//getEnemyStatus(1);

		//makePlayerData();
		//heroData();
    }


    void Update()
    {
        //if (TurnControl.instance.currentState == TurnControl.GameState.Over)
        //{
        //    if (condition)
        //    {

        //        int x = Random.Range(1, 7);
        //        getEnemyStatus(x);
        //        condition = false;

        //    }


        //}
        //else if(TurnControl.instance.currentState == TurnControl.GameState.Game){

        //    condition = true;
        //}
        //Debug.Log(isEnd);
    }

    void make1(){
        AVObject gameScore = new AVObject("GameScore");
        gameScore["score"] = 1337;
        gameScore["playerName"] = "Neal Caffrey";
        Task saveTask = gameScore.SaveAsync();
        Debug.Log(gameScore);
    }


    
	void makeBag(string playId){
		AVQuery<AVObject> playerBag = new AVQuery<AVObject>("Bag").WhereEqualTo("objectId", playId);
        

        
		playerBag.FirstAsync().ContinueWith(t =>
        {
            AVObject myBag = t.Result;
            
			for (int i = 0; i < 60; i++)
            {
				int x = myBag.Get<int>(string.Format("{0}", i));
				PlayerData.Instance.itemList.Add(x,0);
            }



        });
	}
	public void readHeroData(string heroID) { 
		AVQuery<AVObject> query = new AVQuery<AVObject>("HeroData").WhereEqualTo("heroID", heroID);

        query.FirstAsync().ContinueWith(t =>
        {
            AVObject myHero = t.Result;
	      

			HeroStatus.instance.BaseStatus.HeroName = myHero.Get<string>("HeroName");
			HeroStatus.instance.BaseStatus.HeroID = myHero.Get<string>("heroID");
			HeroStatus.instance.BaseStatus.LV = myHero.Get<int>("LV");
			HeroStatus.instance.BaseStatus.S = myHero.Get<int>("S");
			HeroStatus.instance.BaseStatus.P = myHero.Get<int>("P");
			HeroStatus.instance.BaseStatus.D = myHero.Get<int>("D");
			HeroStatus.instance.BaseStatus.A = myHero.Get<int>("A");
			HeroStatus.instance.BaseStatus.I = myHero.Get<int>("I");

			HeroStatus.instance.BaseStatus.HP = myHero.Get<int>("HP");
			HeroStatus.instance.BaseStatus.MP = myHero.Get<int>("MP");
			HeroStatus.instance.BaseStatus.Comprehension = myHero.Get<int>("Comprehension");
			HeroStatus.instance.BaseStatus.luck = myHero.Get<int>("luck");

			HeroStatus.instance.BaseStatus.AtkValue = myHero.Get<int>("AtkValue");
			HeroStatus.instance.BaseStatus.DefValue = myHero.Get<int>("DefValue");
			HeroStatus.instance.BaseStatus.AValue = myHero.Get<int>("AValue");
			HeroStatus.instance.BaseStatus.MagicAtk = myHero.Get<int>("MagicAtk");
			HeroStatus.instance.BaseStatus.MagicDef = myHero.Get<int>("MagicDef");
			HeroStatus.instance.BaseStatus.AttackSpeed =myHero.Get<int>("AttackSpeed");
			HeroStatus.instance.BaseStatus.Exp = myHero.Get<int>("Exp");
			HeroStatus.instance.BaseStatus.Crit = myHero.Get<int>("Crit");
			HeroStatus.instance.BaseStatus.CritDamage = myHero.Get<int>("CritDamage");
			HeroStatus.instance.BaseStatus.Hit = myHero.Get<int>("Hit");
			HeroStatus.instance.BaseStatus.Agl = myHero.Get<int>("Agl");
            //HeroStatus.instance.use_activeSkillAttack = enemy.use_activeSkillAttack;
			HeroStatus.instance.BaseStatus.HPRecoverPerSecond = myHero.Get<int>("HPRecoverPerSecond");
			HeroStatus.instance.BaseStatus.MPRecoverPerSecond = myHero.Get<int>("MPRecoverPerSecond");
			HeroStatus.instance.haveActiveskill = myHero.Get<string>("use_activeSkillAttack");
			HeroStatus.instance.haveArmor = myHero.Get<string>("equiped_armor");
			HeroStatus.instance.UpdateAttribute();
        });
}

    public   void  getEnemyStatus(int enemyID){

        AVQuery<AVObject> query = new AVQuery<AVObject>("enemy").WhereEqualTo("enemyId", enemyID);

        query.FirstAsync().ContinueWith(t =>
        {
            AVObject myEnemy = t.Result;
            string name = myEnemy.Get<string>("enemyName");
            //Debug.Log(name);
            EnemyStatus.instance.BaseStatus.EnemyName = name;
            EnemyStatus.instance.BaseStatus.S =myEnemy.Get<int >("S");
            EnemyStatus.instance.BaseStatus.P = myEnemy.Get<int>("P");
            EnemyStatus.instance.BaseStatus.D= myEnemy.Get<int>("D");
            EnemyStatus.instance.BaseStatus.A = myEnemy.Get<int>("A");
            EnemyStatus.instance.BaseStatus.I = myEnemy.Get<int>("I");

        });


    }

    public string getItemType(int itemID)
    {
        isFind = false;
        AVQuery<AVObject> equipmentType = new AVQuery<AVObject>("equipment").WhereEqualTo("id", itemID);

        equipmentType.FirstAsync().ContinueWith(t =>
        {
            AVObject myEquip1 = t.Result;
            string thistype = myEquip1.Get<string>("equipType");
            isFind = true;
            return thistype;

        });
        return null;
       
    }
    public void getEquipmentStatus(int itemID)
    {
        
        isEnd = false;
        if (itemID != 0)
        {
            //Debug.Log("aaaa"+itemID);
            AVQuery<AVObject> equipment = new AVQuery<AVObject>("equipment").WhereEqualTo("id", itemID);
            //Debug.Log("bbbb" + itemID);
            equipment.FirstAsync().ContinueWith(t =>
            {
                //Debug.Log("ddddd" + itemID);
                AVObject myEquip = t.Result;
                //Debug.Log("ccccc" + itemID);
                type=myEquip.Get<string>("equipType").Trim();
                //Debug.Log(itemID+"的类型？" + type);
                //print(type+"111");
                //print("Weapon111");
               
                if(type=="Weapon"){
                    //Debug.Log("是武器的有哪些？"+itemID);
                    //Debug.Log(myEquip.Get<string>("name"));
                    Weapon.ID = myEquip.Get<int>("id");
                    Weapon.Name = myEquip.Get<string>("name");
                    //Debug.Log(myEquip.Get<string>("name"));
                    Weapon.Type = myEquip.Get<string>("type");
                    //Debug.Log(myEquip.Get<string>("type"));
                    Weapon.Quality = myEquip.Get<string>("quality");
                    //Debug.Log(myEquip.Get<string>("quality"));
                    Weapon.Description = myEquip.Get<string>("description");
                    //Debug.Log(myEquip.Get<string>("description"));
                    Weapon.Capacity = myEquip.Get<int>("capacity");
                    //Debug.Log(myEquip.Get<int>("capacity"));
                    Weapon.BuyPrice = myEquip.Get<int>("buyPrice");
                    //Debug.Log(myEquip.Get<int>("buyPrice"));
                    Weapon.SellPrice = myEquip.Get<int>("sellPrice");
                    //Debug.Log(myEquip.Get<int>("sellPrice"));
                    Weapon.Sprite = myEquip.Get<string>("sprite");
                    //Debug.Log(myEquip.Get<string>("sprite"));
                    Weapon.HP = myEquip.Get<int>("hp");
                    //Debug.Log("装备获得了"+Weapon.HP);
                    //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
                    Weapon.MP = myEquip.Get<int>("mp");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Weapon.S = myEquip.Get<int>("S");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Weapon.P = myEquip.Get<int>("P");
                    Weapon.D = myEquip.Get<int>("D");
                    Weapon.A = myEquip.Get<int>("A");
                    Weapon.I = myEquip.Get<int>("I");
                    Weapon.AtkValue = myEquip.Get<int>("atkValue");
                    Weapon.DefValue = myEquip.Get<int>("defValue");
                    Weapon.AValue = myEquip.Get<int>("aValue");
                    Weapon.MagicAtk = myEquip.Get<int>("magicAtk");
                    Weapon.MagicDef = myEquip.Get<int>("magicDef");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
                    Weapon.Comprehension = myEquip.Get<int>("comprehension");
                    Weapon.Luck = myEquip.Get<int>("luck");
                    Weapon.AttackSpeed = myEquip.Get<int>("attackSpeed");
                    Weapon.stamina = myEquip.Get<int>("stamina");
                    Weapon.Crit = myEquip.Get<int>("crit");
                    Weapon.CritDamage = myEquip.Get<int>("critDamage");
                    Weapon.Hit = myEquip.Get<int>("hit");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
                    Weapon.Agl = myEquip.Get<int>("agl");
                    Weapon.Counter = myEquip.Get<int>("counter");
                    Weapon.Double = myEquip.Get<int>("double");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
                    Weapon.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
                    Weapon.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
                    Weapon.EquipType = myEquip.Get<string>("equipType");
                    Weapon.requiredS = myEquip.Get<int>("requiredS");
                    Weapon.requiredP = myEquip.Get<int>("requiredP");
                    Weapon.requiredD = myEquip.Get<int>("requiredD");
                    Weapon.requiredA = myEquip.Get<int>("requiredA");
                    Weapon.requiredI = myEquip.Get<int>("requiredI");
                }
                else if(type == "Head"){
                    Head.ID = myEquip.Get<int>("id");
                    Head.Name = myEquip.Get<string>("name");
                    //Debug.Log(myEquip.Get<string>("name"));
                    Head.Type = myEquip.Get<string>("type");
                    //Debug.Log(myEquip.Get<string>("type"));
                    Head.Quality = myEquip.Get<string>("quality");
                    //Debug.Log(myEquip.Get<string>("quality"));
                    Head.Description = myEquip.Get<string>("description");
                    //Debug.Log(myEquip.Get<string>("description"));
                    Head.Capacity = myEquip.Get<int>("capacity");
                    //Debug.Log(myEquip.Get<int>("capacity"));
                    Head.BuyPrice = myEquip.Get<int>("buyPrice");
                    //Debug.Log(myEquip.Get<int>("buyPrice"));
                    Head.SellPrice = myEquip.Get<int>("sellPrice");
                    //Debug.Log(myEquip.Get<int>("sellPrice"));
                    Head.Sprite = myEquip.Get<string>("sprite");
                    //Debug.Log(myEquip.Get<string>("sprite"));
                    Head.HP = myEquip.Get<int>("hp");
                    //Debug.Log("装备获得了"+Head.HP);
                    //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
                    Head.MP = myEquip.Get<int>("mp");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Head.S = myEquip.Get<int>("S");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Head.P = myEquip.Get<int>("P");
                    Head.D = myEquip.Get<int>("D");
                    Head.A = myEquip.Get<int>("A");
                    Head.I = myEquip.Get<int>("I");
                    Head.AtkValue = myEquip.Get<int>("atkValue");
                    Head.DefValue = myEquip.Get<int>("defValue");
                    Head.AValue = myEquip.Get<int>("aValue");
                    Head.MagicAtk = myEquip.Get<int>("magicAtk");
                    Head.MagicDef = myEquip.Get<int>("magicDef");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
                    Head.Comprehension = myEquip.Get<int>("comprehension");
                    Head.Luck = myEquip.Get<int>("luck");
                    Head.AttackSpeed = myEquip.Get<int>("attackSpeed");
                    Head.stamina = myEquip.Get<int>("stamina");
                    Head.Crit = myEquip.Get<int>("crit");
                    Head.CritDamage = myEquip.Get<int>("critDamage");
                    Head.Hit = myEquip.Get<int>("hit");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
                    Head.Agl = myEquip.Get<int>("agl");
                    Head.Counter = myEquip.Get<int>("counter");
                    Head.Double = myEquip.Get<int>("double");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
                    Head.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
                    Head.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
                    Head.EquipType = myEquip.Get<string>("equipType");
                    Head.requiredS = myEquip.Get<int>("requiredS");
                    Head.requiredP = myEquip.Get<int>("requiredP");
                    Head.requiredD = myEquip.Get<int>("requiredD");
                    Head.requiredA = myEquip.Get<int>("requiredA");
                    Head.requiredI = myEquip.Get<int>("requiredI");
                }
                else if (type == "Chest")
                {
                    Chest.ID = myEquip.Get<int>("id");
                    Chest.Name = myEquip.Get<string>("name");
                    //Debug.Log(myEquip.Get<string>("name"));
                    Chest.Type = myEquip.Get<string>("type");
                    //Debug.Log(myEquip.Get<string>("type"));
                    Chest.Quality = myEquip.Get<string>("quality");
                    //Debug.Log(myEquip.Get<string>("quality"));
                    Chest.Description = myEquip.Get<string>("description");
                    //Debug.Log(myEquip.Get<string>("description"));
                    Chest.Capacity = myEquip.Get<int>("capacity");
                    //Debug.Log(myEquip.Get<int>("capacity"));
                    Chest.BuyPrice = myEquip.Get<int>("buyPrice");
                    //Debug.Log(myEquip.Get<int>("buyPrice"));
                    Chest.SellPrice = myEquip.Get<int>("sellPrice");
                    //Debug.Log(myEquip.Get<int>("sellPrice"));
                    Chest.Sprite = myEquip.Get<string>("sprite");
                    //Debug.Log(myEquip.Get<string>("sprite"));
                    Chest.HP = myEquip.Get<int>("hp");
                    //Debug.Log("装备获得了"+Chest.HP);
                    //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
                    Chest.MP = myEquip.Get<int>("mp");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Chest.S = myEquip.Get<int>("S");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Chest.P = myEquip.Get<int>("P");
                    Chest.D = myEquip.Get<int>("D");
                    Chest.A = myEquip.Get<int>("A");
                    Chest.I = myEquip.Get<int>("I");
                    Chest.AtkValue = myEquip.Get<int>("atkValue");
                    Chest.DefValue = myEquip.Get<int>("defValue");
                    Chest.AValue = myEquip.Get<int>("aValue");
                    Chest.MagicAtk = myEquip.Get<int>("magicAtk");
                    Chest.MagicDef = myEquip.Get<int>("magicDef");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
                    Chest.Comprehension = myEquip.Get<int>("comprehension");
                    Chest.Luck = myEquip.Get<int>("luck");
                    Chest.AttackSpeed = myEquip.Get<int>("attackSpeed");
                    Chest.stamina = myEquip.Get<int>("stamina");
                    Chest.Crit = myEquip.Get<int>("crit");
                    Chest.CritDamage = myEquip.Get<int>("critDamage");
                    Chest.Hit = myEquip.Get<int>("hit");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
                    Chest.Agl = myEquip.Get<int>("agl");
                    Chest.Counter = myEquip.Get<int>("counter");
                    Chest.Double = myEquip.Get<int>("double");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
                    Chest.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
                    Chest.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
                    Chest.EquipType = myEquip.Get<string>("equipType");
                    Chest.requiredS = myEquip.Get<int>("requiredS");
                    Chest.requiredP = myEquip.Get<int>("requiredP");
                    Chest.requiredD = myEquip.Get<int>("requiredD");
                    Chest.requiredA = myEquip.Get<int>("requiredA");
                    Chest.requiredI = myEquip.Get<int>("requiredI");
                }
                else if (type == "Leg")
                {
                    Leg.ID = myEquip.Get<int>("id");
                    Leg.Name = myEquip.Get<string>("name");
                    //Debug.Log(myEquip.Get<string>("name"));
                    Leg.Type = myEquip.Get<string>("type");
                    //Debug.Log(myEquip.Get<string>("type"));
                    Leg.Quality = myEquip.Get<string>("quality");
                    //Debug.Log(myEquip.Get<string>("quality"));
                    Leg.Description = myEquip.Get<string>("description");
                    //Debug.Log(myEquip.Get<string>("description"));
                    Leg.Capacity = myEquip.Get<int>("capacity");
                    //Debug.Log(myEquip.Get<int>("capacity"));
                    Leg.BuyPrice = myEquip.Get<int>("buyPrice");
                    //Debug.Log(myEquip.Get<int>("buyPrice"));
                    Leg.SellPrice = myEquip.Get<int>("sellPrice");
                    //Debug.Log(myEquip.Get<int>("sellPrice"));
                    Leg.Sprite = myEquip.Get<string>("sprite");
                    //Debug.Log(myEquip.Get<string>("sprite"));
                    Leg.HP = myEquip.Get<int>("hp");
                    //Debug.Log("装备获得了"+Leg.HP);
                    //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
                    Leg.MP = myEquip.Get<int>("mp");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Leg.S = myEquip.Get<int>("S");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Leg.P = myEquip.Get<int>("P");
                    Leg.D = myEquip.Get<int>("D");
                    Leg.A = myEquip.Get<int>("A");
                    Leg.I = myEquip.Get<int>("I");
                    Leg.AtkValue = myEquip.Get<int>("atkValue");
                    Leg.DefValue = myEquip.Get<int>("defValue");
                    Leg.AValue = myEquip.Get<int>("aValue");
                    Leg.MagicAtk = myEquip.Get<int>("magicAtk");
                    Leg.MagicDef = myEquip.Get<int>("magicDef");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
                    Leg.Comprehension = myEquip.Get<int>("comprehension");
                    Leg.Luck = myEquip.Get<int>("luck");
                    Leg.AttackSpeed = myEquip.Get<int>("attackSpeed");
                    Leg.stamina = myEquip.Get<int>("stamina");
                    Leg.Crit = myEquip.Get<int>("crit");
                    Leg.CritDamage = myEquip.Get<int>("critDamage");
                    Leg.Hit = myEquip.Get<int>("hit");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
                    Leg.Agl = myEquip.Get<int>("agl");
                    Leg.Counter = myEquip.Get<int>("counter");
                    Leg.Double = myEquip.Get<int>("double");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
                    Leg.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
                    Leg.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
                    Leg.EquipType = myEquip.Get<string>("equipType");
                    Leg.requiredS = myEquip.Get<int>("requiredS");
                    Leg.requiredP = myEquip.Get<int>("requiredP");
                    Leg.requiredD = myEquip.Get<int>("requiredD");
                    Leg.requiredA = myEquip.Get<int>("requiredA");
                    Leg.requiredI = myEquip.Get<int>("requiredI");
                }
                else if (type == "Ring")
                {
                    Ring.ID = myEquip.Get<int>("id");
                    Ring.Name = myEquip.Get<string>("name");
                    //Debug.Log(myEquip.Get<string>("name"));
                    Ring.Type = myEquip.Get<string>("type");
                    //Debug.Log(myEquip.Get<string>("type"));
                    Ring.Quality = myEquip.Get<string>("quality");
                    //Debug.Log(myEquip.Get<string>("quality"));
                    Ring.Description = myEquip.Get<string>("description");
                    //Debug.Log(myEquip.Get<string>("description"));
                    Ring.Capacity = myEquip.Get<int>("capacity");
                    //Debug.Log(myEquip.Get<int>("capacity"));
                    Ring.BuyPrice = myEquip.Get<int>("buyPrice");
                    //Debug.Log(myEquip.Get<int>("buyPrice"));
                    Ring.SellPrice = myEquip.Get<int>("sellPrice");
                    //Debug.Log(myEquip.Get<int>("sellPrice"));
                    Ring.Sprite = myEquip.Get<string>("sprite");
                    //Debug.Log(myEquip.Get<string>("sprite"));
                    Ring.HP = myEquip.Get<int>("hp");
                    //Debug.Log("装备获得了"+Ring.HP);
                    //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
                    Ring.MP = myEquip.Get<int>("mp");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Ring.S = myEquip.Get<int>("S");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
                    Ring.P = myEquip.Get<int>("P");
                    Ring.D = myEquip.Get<int>("D");
                    Ring.A = myEquip.Get<int>("A");
                    Ring.I = myEquip.Get<int>("I");
                    Ring.AtkValue = myEquip.Get<int>("atkValue");
                    Ring.DefValue = myEquip.Get<int>("defValue");
                    Ring.AValue = myEquip.Get<int>("aValue");
                    Ring.MagicAtk = myEquip.Get<int>("magicAtk");
                    Ring.MagicDef = myEquip.Get<int>("magicDef");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
                    Ring.Comprehension = myEquip.Get<int>("comprehension");
                    Ring.Luck = myEquip.Get<int>("luck");
                    Ring.AttackSpeed = myEquip.Get<int>("attackSpeed");
                    Ring.stamina = myEquip.Get<int>("stamina");
                    Ring.Crit = myEquip.Get<int>("crit");
                    Ring.CritDamage = myEquip.Get<int>("critDamage");
                    Ring.Hit = myEquip.Get<int>("hit");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
                    Ring.Agl = myEquip.Get<int>("agl");
                    Ring.Counter = myEquip.Get<int>("counter");
                    Ring.Double = myEquip.Get<int>("double");
                    //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
                    Ring.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
                    Ring.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
                    Ring.EquipType = myEquip.Get<string>("equipType");
                    Ring.requiredS = myEquip.Get<int>("requiredS");
                    Ring.requiredP = myEquip.Get<int>("requiredP");
                    Ring.requiredD = myEquip.Get<int>("requiredD");
                    Ring.requiredA = myEquip.Get<int>("requiredA");
                    Ring.requiredI = myEquip.Get<int>("requiredI");
                }
                else{
                    Debug.Log("!!!!!!!!1");
                }
                isEnd = true;
                //Debug.Log("3333333333"+isEnd);
                //Debug.Log(myEquip.Get<string>("name"));
            });
        }

    }

    //public void getEquipmentStatus(int itemID)
    //{
    //    isEnd = false;
    //    if (itemID != 0)
    //    {


    //        AVQuery<AVObject> equipment = new AVQuery<AVObject>("equipment").WhereEqualTo("id", itemID);

    //        equipment.FirstAsync().ContinueWith(t =>
    //        {
    //            AVObject myEquip = t.Result;
    //            Equipment.Instance.ID = myEquip.Get<int>("id");
    //            Equipment.Instance.Name = myEquip.Get<string>("name");
    //            //Debug.Log(myEquip.Get<string>("name"));
    //            Equipment.Instance.Type = myEquip.Get<string>("type");
    //            //Debug.Log(myEquip.Get<string>("type"));
    //            Equipment.Instance.Quality = myEquip.Get<string>("quality");
    //            //Debug.Log(myEquip.Get<string>("quality"));
    //            Equipment.Instance.Description = myEquip.Get<string>("description");
    //            //Debug.Log(myEquip.Get<string>("description"));
    //            Equipment.Instance.Capacity = myEquip.Get<int>("capacity");
    //            //Debug.Log(myEquip.Get<int>("capacity"));
    //            Equipment.Instance.BuyPrice = myEquip.Get<int>("buyPrice");
    //            //Debug.Log(myEquip.Get<int>("buyPrice"));
    //            Equipment.Instance.SellPrice = myEquip.Get<int>("sellPrice");
    //            //Debug.Log(myEquip.Get<int>("sellPrice"));
    //            Equipment.Instance.Sprite = myEquip.Get<string>("sprite");
    //            //Debug.Log(myEquip.Get<string>("sprite"));
    //            Equipment.Instance.HP = myEquip.Get<int>("hp");
    //            //Debug.Log("装备获得了"+Equipment.Instance.HP);
    //            //Debug.Log(myEquip.Get<string>("name")+"装备获得的hp是"+myEquip.Get<int>("hp"));
    //            Equipment.Instance.MP = myEquip.Get<int>("mp");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
    //            Equipment.Instance.S = myEquip.Get<int>("S");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的mp是" +myEquip.Get<int>("mp"));
    //            Equipment.Instance.P = myEquip.Get<int>("P");
    //            Equipment.Instance.D = myEquip.Get<int>("D");
    //            Equipment.Instance.A = myEquip.Get<int>("A");
    //            Equipment.Instance.I = myEquip.Get<int>("I");
    //            Equipment.Instance.AtkValue = myEquip.Get<int>("atkValue");
    //            Equipment.Instance.DefValue = myEquip.Get<int>("defValue");
    //            Equipment.Instance.AValue = myEquip.Get<int>("aValue");
    //            Equipment.Instance.MagicAtk = myEquip.Get<int>("magicAtk");
    //            Equipment.Instance.MagicDef = myEquip.Get<int>("magicDef");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的magicDef是" +myEquip.Get<int>("magicDef"));
    //            Equipment.Instance.Comprehension = myEquip.Get<int>("comprehension");
    //            Equipment.Instance.Luck = myEquip.Get<int>("luck");
    //            Equipment.Instance.AttackSpeed = myEquip.Get<int>("attackSpeed");
    //            Equipment.Instance.stamina = myEquip.Get<int>("stamina");
    //            Equipment.Instance.Crit = myEquip.Get<int>("crit");
    //            Equipment.Instance.CritDamage = myEquip.Get<int>("critDamage");
    //            Equipment.Instance.Hit = myEquip.Get<int>("hit");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的hit是" + myEquip.Get<int>("hit"));
    //            Equipment.Instance.Agl = myEquip.Get<int>("agl");
    //            Equipment.Instance.Counter = myEquip.Get<int>("counter");
    //            Equipment.Instance.Double = myEquip.Get<int>("double");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的double是" + myEquip.Get<int>("double"));
    //            Equipment.Instance.HPRecoverPerSecond = myEquip.Get<int>("hpRecoverPerSecond");
    //            Equipment.Instance.MPRecoverPerSecond = myEquip.Get<int>("mpRecoverPerSecond");
    //            Equipment.Instance.EquipType = myEquip.Get<string>("equipType");
    //            Equipment.Instance.requiredS = myEquip.Get<int>("requiredS");
    //            Equipment.Instance.requiredP = myEquip.Get<int>("requiredP");
    //            Equipment.Instance.requiredD = myEquip.Get<int>("requiredD");
    //            Equipment.Instance.requiredA = myEquip.Get<int>("requiredA");
    //            Equipment.Instance.requiredI = myEquip.Get<int>("requiredI");
    //            //Debug.Log(myEquip.Get<string>("name") + "装备获得的requiredI是" + myEquip.Get<int>("requiredI"));

    //            isEnd = true;
    //            //Debug.Log("3333333333"+isEnd);
    //        });
    //    }
    //    else{
    //        Equipment.Instance.ID = 0;
    //        Equipment.Instance.Name = "";
    //        Equipment.Instance.Type = "";
    //        Equipment.Instance.Quality = "";
    //        Equipment.Instance.Description = "";
    //        Equipment.Instance.Capacity = 0;
    //        Equipment.Instance.BuyPrice = 0;
    //        Equipment.Instance.SellPrice = 0;
    //        Equipment.Instance.Sprite = "";
    //        Equipment.Instance.HP = 0;
    //        Equipment.Instance.HP = 0;
    //        Equipment.Instance.MP = 0;
    //        Equipment.Instance.S = 0;
    //        Equipment.Instance.P = 0;
    //        Equipment.Instance.D = 0;
    //        Equipment.Instance.A = 0;
    //        Equipment.Instance.I = 0;
    //        Equipment.Instance.AtkValue = 0;
    //        Equipment.Instance.DefValue = 0;
    //        Equipment.Instance.AValue = 0;
    //        Equipment.Instance.IValue = 0;
    //        Equipment.Instance.MagicAtk = 0;
    //        Equipment.Instance.MagicDef = 0;
    //        Equipment.Instance.Comprehension = 0;
    //        Equipment.Instance.Luck = 0;
    //        Equipment.Instance.AttackSpeed = 0;
    //        Equipment.Instance.stamina = 0;
    //        Equipment.Instance.Crit = 0;
    //        Equipment.Instance.CritDamage = 0;
    //        Equipment.Instance.Hit = 0;
    //        Equipment.Instance.Agl = 0;
    //        Equipment.Instance.Counter = 0;
    //        Equipment.Instance.Double = 0;
    //        Equipment.Instance.HPRecoverPerSecond = 0;
    //        Equipment.Instance.MPRecoverPerSecond = 0;
    //        Equipment.Instance.Exp = 0;
    //        Equipment.Instance.EquipType = "";
    //        Equipment.Instance.requiredS = 0;
    //        Equipment.Instance.requiredP = 0;
    //        Equipment.Instance.requiredD = 0;
    //        Equipment.Instance.requiredA = 0;
    //        Equipment.Instance.requiredI = 0;
    //        isEnd = true;
    //    }



    //}


    void check(AVObject mygameScore){
        

        int score = mygameScore.Get<int>("score");
        string playerName = mygameScore.Get<string>("playerName");
        Debug.Log(score);
        Debug.Log(playerName);
        AVQuery<AVObject> query = new AVQuery<AVObject>("GameScore");
        query.GetAsync("53706cd1e4b0d4bef5eb32ab").ContinueWith(t =>
        {
            AVObject gameScore = t.Result;//如果成功获取，t.Result将是一个合法有效的AVObject

        });


    }
    void updateData()
    {

        var gameScore = new AVObject("GameScore")
    {
        { "score", 1338 },
        { "playerName", "Peter Burke" },
        { "cheatMode", false },
        { "skills", new List<string> { "FBI", "Agent Leader" } },
    };//创建一个全新的 GameScore 对象

        gameScore.SaveAsync().ContinueWith(t =>//第一次调用 SaveAsync 是为了增加这个全新的对象
    {
        // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改 cheatMode 和 score
        // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的 playerName 不会被修改
        gameScore["cheatMode"] = true;
        gameScore["score"] = 9999;
        gameScore.SaveAsync();//第二次调用是为了把刚才修改的2个属性发送到服务端生效。
    });
    }



    public void Singup()
    {
        var user = new AVUser();
        user.Username = SystemInfo.deviceUniqueIdentifier;  //唯一识别码
        user.Password = SystemInfo.deviceUniqueIdentifier.Substring(2, 14);
        user["testA"] = "aaa";
        user.SignUpAsync().ContinueWith(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.Log(t.Exception.Message);
            }
            else
            {
                Debug.Log(t.Exception.Message);
                string uid = user.ObjectId;
            }
        });

    }


        void updataData()
        {
            //updata data
            AVObject ao = AVUser.CurrentUser;
            ao["testA"] = "a5";

            //add remove
            ao.Add("testB", "b1");
            ao.Remove("testA");

            //link focusType 使用链接对象
            AVObject sceneData = new AVObject("GirType");
            sceneData["typeName"] = "class1";
            ao["SceneData"] = sceneData;

            //Async
            ao.SaveAsync();


        }



















   // private string userName;
   // private string userID;
   // private bool isLogin = false;

   // public bool IsLogin;
   // public string UserName;
   // public string UserID;


   // private static CloudManager _instance;  
   // public static CloudManager Instance  
   // {  
   //     get  
   //     {  
   //         if(_instance==null)  
   //             return new CloudManager();  
   //         return _instance;  
   //     }  
   // }  

   // public  bool 登陆(string userName,string passWord)//登陆检测  
   // {  
   //     bool isOK = false;  
   //     AVUser.LogInAsync(userName, passWord).ContinueWith(t =>  
   //     {  
   //         if (t.IsFaulted || t.IsCanceled)  
   //         {  
   //             var error = t.Exception.Message; // 登录失败，可以查看错误信息。  
   //             isOK = false;  
   //         }  
   //         else  
   //         {  
  
   //             var user = t.Result;  
   //             isOK = true;  
   //             UserName = userName;  
   //             UserID = user.ObjectId;  
   //             print("登陆成功");  
   //             //登录成功  
   //         }  
   //     });  
   //     if (isOK)  
   //         return true;  
   //     else return false;  
   // }  

   // public bool 注册(string userName,string passWord,string userEmail)  
   // {  
   //     bool isOK = false;  
   //     var user = new AVUser();  
   //     user.Username = userName;  
   //     user.Password = passWord;  
   //     user.Email = userEmail;  
   //     //注册 异步请求   
   //     user.SignUpAsync().ContinueWith(t =>  
   //     {  
   //         if (t.IsCanceled || t.IsFaulted)//判断登陆状态  
   //             isOK = false;  
   //         UserName = userName;  
   //         UserID = user.ObjectId;  
   //         isOK = true;  
   //         print("登陆成功userID=" + UserID);  
   //     });  
   //     //用户注册成功返回false  
   //     if (isOK)  
   //         return true;  
   //     else return false;  
   // }  

   // public bool 更新个人信息(string sex,string age,string imageUrl)  
   // {  
   //     bool isOk = true;  
   //     //通过UserInfo 和 userName 找到表格对应的对象 sex age imageUrl   
   //     AVQuery<AVObject> query = AVObject.GetQuery("UserInfo").WhereEqualTo("userName", UserName);  
   //     query.FindAsync().ContinueWith(t =>  
   //     {  
   //         if (t.IsCanceled || t.IsFaulted)  
   //         {  
   //             print("没有查到该用户");  
   //             isOk = false;  
   //         }  
   //         var players = t.Result;  
   //         IEnumerator<AVObject> enumerator = players.GetEnumerator();  
   //         enumerator.MoveNext();  
   //         var userInfo = enumerator.Current;//获取目前得分排名第一的玩家  
  
   //         userInfo["sex"] = sex;  
   //         userInfo["age"] = age;  
   //         userInfo["ImageUrl"] = imageUrl;  
   //         return userInfo.SaveAsync();  
   //     }).Unwrap().ContinueWith(t =>  
   //     {  
   //         if (t.IsCanceled || t.IsFaulted)  
   //         {  
   //             print("没有保存成功！");  
   //             isOk = false;  
   //         }  
   //         return query.FindAsync();//为了保证数据正确可以再查一遍  
   //     }).Unwrap().ContinueWith(t =>  
   //     {  
   //         if (t.IsCanceled || t.IsFaulted)  
   //         {  
   //             print("检查没通过");  
   //             isOk = false;  
   //         }  
   //     });  
  
   //     if (isOk)  
   //         return true;  
   //     else return false;  
   // }  



   // public bool 更新得分信息(int score)  
   //{  
   //    bool isOK = true;  
   //    AVQuery<AVObject> query = new AVQuery<AVObject>("UserScore")  
   //        .WhereEqualTo("userName", this.UserName);  
   //    query.FindAsync().ContinueWith(t =>  
   //    {  
   //        if (t.IsCanceled || t.IsFaulted)  
   //        {  
   //            isOK = false;  
   //        }  
   //        var players = t.Result;  
   //        IEnumerator<AVObject> enumerator = players.GetEnumerator();  
   //        var user = enumerator.Current;  
   //        user["AllScore"] = score;  
   //        return user.SaveAsync();  
   //    }).Unwrap().ContinueWith(t =>  
   //    {  
   //        if (t.IsCanceled || t.IsFaulted)  
   //        {  
   //            print("更新失败");  
   //            isOK = false;  
   //        }  
             
   //    });  
   //    if (isOK)  
   //        return true;  
   //    else  
   //        return false;  
   //}  


   // public bool 显示排行榜()  
   //{  
   //    bool isOK = true;  
   //    AVQuery<AVObject> query = new AVQuery<AVObject>("UserScore")  
   //        .WhereNotEqualTo("AllScore", "")  
   //        .OrderBy("AllScore")  
   //        .OrderByDescending("AllScore");//排序  
   //    query.FindAsync().ContinueWith(t =>  
   //    {  
   //        if (t.IsCanceled)  
   //        {  
   //            isOK = false;  
   //            print("被取消了！");  
   //        }  
   //        else if (t.IsFaulted)  
   //        {  
   //            isOK = false;  
   //            print("失败了");  
   //        }  
   //        else  
   //        {  
   //            var players = t.Result;  
   //            IEnumerator<AVObject> enumerator = players.GetEnumerator();  
   //            int i = 0;  
   //            List<string> myList = new List<string>();  
   //            var user = new AVObject("UserScore");  
   //            while (enumerator.MoveNext())  
   //            {  
   //                i++;  
   //                var golden_player = enumerator.Current;//  
   //                print("玩家得分" + golden_player["userName"] + " :" + golden_player["AllScore"]);  
   //                myList.Add(golden_player["userName"] + " :" + golden_player["AllScore"]);  
   //                if (golden_player["userName"].Equals(this.UserName))  
   //                {  
   //                    user = golden_player;//获取到了自己的分数  
   //                }  
   //            }  
   //            print("总玩家数：" + i);         
   //            //// enumerator.MoveNext();  
   //            //for (i = 1; i <= 20; i++)  
   //            //{  
   //            //    text = GameObject.Find("主界面/Scroll View(Clone)/Viewport/Content/Text" + i).GetComponent<Text>();  
   //            //    text.text = myList[i-1];  
   //            //}  
                 
   //        }  
   //    });  
   //    if (isOK)  
   //        return true;  
   //    else  
   //        return false;  
   //}  




}
