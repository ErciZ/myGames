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
		   UserID = user.ObjectId;
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
    //public  bool 登陆(string userName,string passWord)//登陆检测  
    //{  
    //    bool isOK = false;  
    //    AVUser.LogInAsync(userName, passWord).ContinueWith(t =>  
    //    {  
    //        if (t.IsFaulted || t.IsCanceled)  
    //        {  
    //            var error = t.Exception.Message; // 登录失败，可以查看错误信息。  
    //            isOK = false;  
    //        }  
    //        else  
    //        {  
  
    //            var user = t.Result;  
    //            isOK = true;  
    //            UserName = userName;  
    //            UserID = user.ObjectId;  
    //            print("登陆成功");  
    //            //登录成功  
    //        }  
    //    });  
    //    if (isOK)  
    //        return true;  
    //    else return false;  
    //}  

    

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
