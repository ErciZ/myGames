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
using System;


public class playerlogin : MonoBehaviour
{
	public static playerlogin instance;
	private string userName;
    private string userID;
    private bool isLogin = false;

    public bool IsLogin;
    public string UserName;
    public string UserID;
	public bool isLoginOK;
	public bool isSignupOK;
	//private EnemyStatus enemy;
	//private TurnControl turnScript; 
	public AVUser thisuser;
 


    private void Awake()
    {
        instance = this;
    }

	internal void login(string username, string password)
	{
		throw new NotImplementedException();
	}

	private void Start()
    {
        //enemy = GameObject.Find("enemy(Clone)").GetComponent<EnemyStatus>();
        //turnScript = GameObject.Find("TurnSystem").GetComponent<TurnControl>();
        
        //getEnemyStatus(1);
		//makeBag();
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


	public void Singup(string userName, string passWord){
		isSignupOK = false;  
        var user = new AVUser();
        user.Username = userName;
		user.Password = passWord;
		user.SignUpAsync().ContinueWith(t =>
	   {
	   if (t.IsFaulted || t.IsCanceled)
	   {
		   isSignupOK = false;
		   Debug.Log("注册失败");
	   }
	   else
	   {
		   string uid = user.ObjectId;
				thisuser = AVUser.CurrentUser;
		   UserName = userName;
				UserID = thisuser.ObjectId;
		   isSignupOK = true;
				makePlayerData(UserID);
		   Debug.Log("登陆成功userID=" + UserID);

		   
           }
       });
	}   
	public  void Login(string userName,string passWord)//登陆检测  
     {  
		 isLoginOK = false;
		AVUser.LogInAsync(userName, passWord).ContinueWith(t =>
		{
		if (t.IsFaulted || t.IsCanceled)
		{
			var error = t.Exception.Message; // 登录失败，可以查看错误信息。  
			isLoginOK = false;
		}
		else
		{

			var user = t.Result;
			isLoginOK = true;
			UserName = userName;
			UserID = user.ObjectId;            
                Debug.Log("登陆成功");
                Debug.Log("用户ID1" + UserID);
                thisuser = AVUser.CurrentUser;
                Debug.Log("用户ID2" + thisuser.ObjectId);
  
             }  
         });  
 
     }  



	public 	void heroData(string uid)
    {
		AVObject heroData = new AVObject("HeroData");

		heroData["heroID"] = uid;
		heroData["HeroName"] = loginButton.instance.name;
		heroData["LV"] = 0;
		heroData["HP"] = 0;
		heroData["MP"] = 0;
		heroData["EP"] = 0;
		heroData["S"] = loginButton.instance.S;
		heroData["P"] = loginButton.instance.P;
		heroData["D"] = loginButton.instance.D;
		heroData["A"] = loginButton.instance.A;
		heroData["I"] = loginButton.instance.I;
		heroData["AtkValue"] = 0;
		heroData["DefValue"] = 0;
		heroData["AValue"] = 0;
		heroData["MagicAtk"] = 0;
		heroData["MagicDef"] = 0;
		heroData["Comprehension"] = 0;
		heroData["luck"] = 0;
		heroData["AttackSpeed"] = 0;
		heroData["Exp"] = 0;
		heroData["Crit"] = 0;
		heroData["CritDamage"] = 0;
		heroData["Hit"] = 0;
		heroData["Agl"] = 0;
		heroData["HPRecoverPerSecond"] = 0;
		heroData["MPRecoverPerSecond"] = 0;


		heroData["use_activeSkillAttack"] = "";
		heroData["equiped_armor"] = "";

		Task saveTask = heroData.SaveAsync();
    }
    void makePlayerData(string uid)
    {
        AVObject PlayerData = new AVObject("PlayerData");

		PlayerData["playerID"] = uid;
        PlayerData["playerName"] = "";
        PlayerData["haveHeroId"] = 0;

        PlayerData["coinAmount"] = 0;
        PlayerData["diamond"] = 0;
        PlayerData["havebagId"] = 0;

        Task saveTask = PlayerData.SaveAsync();
    }
   



}
