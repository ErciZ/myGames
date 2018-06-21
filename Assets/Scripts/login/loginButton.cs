using UnityEngine;
using FairyGUI;
using LeanCloud.Core;
using LeanCloud.Storage;
using LeanCloud.Utilities;
using Unity.Tasks;
using LeanCloud.Realtime;
using LeanCloud;

public class loginButton : MonoBehaviour
{
   


	public static loginButton instance;
	GComponent _mainView;
    BagWindow _bagWindow;
	public GButton login;
	public GButton signup;
	public GTextInput username;
	public GTextInput password ;
	public GTextInput creatname;
	public GTextField randomShow;
	public Controller c1;
	public string user;
	public string pwd;
	public GButton randomStatus;
	public GButton start;
	public int  S, P, D, A, I;
	public string name;

    void Awake()
    {
        //Register custom loader class
        UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));
		instance = this;
	}

    void Start()
    {
        Application.targetFrameRate = 60;
        Stage.inst.onKeyDown.Add(OnKeyDown);
        GRoot.inst.SetContentScaleFactor(720, 1280);
        _mainView = this.GetComponent<UIPanel>().ui;
		playerlogin.instance.thisuser = AVUser.CurrentUser;
		//username = _mainView.GetChild("username").asButton.title;
		//password = _mainView.GetChild("password").asButton.title;


		username = _mainView.GetChild("username").asButton.GetChild("title").asTextInput;
		password = _mainView.GetChild("password").asButton.GetChild("title").asTextInput;
		creatname = _mainView.GetChild("creatname").asButton.GetChild("title").asTextInput;
		randomStatus = _mainView.GetChild("randomStatus").asButton;
		start = _mainView.GetChild("start").asButton;
		//Debug.Log(randomStatus);
		randomShow = _mainView.GetChild("randomShow").asTextField;
		//Debug.Log(username);
		//Debug.Log(password);
		login = _mainView.GetChild("login").asButton;
		signup = _mainView.GetChild("signup").asButton;
		c1 = _mainView.GetController("c1");
		randomShow.text = string.Format("力量：{0}\n体质：{1}\n耐力：{2}\n敏捷：{3}\n智力：{4}\n", S, P, D, A, I);
        

        
        
    }
    
	private void Update()
	{

		username.onChanged.Add(() => { getText_user(username); });
		password.onChanged.Add(() => { getText_pwd(password); });
		randomStatus.onClick.Add(() => { random(randomShow); });
		login.onClick.Add(() => { playerlogin.instance.Login(user, pwd); });
		signup.onClick.Add(() => { playerlogin.instance.Singup(user, pwd); });
		start.onClick.Add(() => { startGame(); });
		if (playerlogin.instance.isSignupOK == true)
        {

			changePagetoCreat(signup, c1);
			playerlogin.instance.isSignupOK = false;
        }
		if (playerlogin.instance.isLoginOK==true){
			CloudManager.instance.readHeroData(playerlogin.instance.thisuser.ObjectId);
			changePagetoMain(login, c1);
			playerlogin.instance.isLoginOK = false;
		}

	}

	void getText_user(GTextInput username){
		user = username.text;
		Debug.Log(user);
		
	}
	void getText_pwd(GTextInput password)
    {
		pwd = password.text;
		Debug.Log(pwd);

    }
	public void changePagetoMain(GButton login,Controller c1)  
{  
		login.pageOption.controller = c1;
		//login.pageOption.index = 1; //通过索引设置
		//c1.setSelectedIndex(1);
		c1.SetSelectedIndex(2);
		//login.pageOption.name = "page_name"; //或通过页面名称设置
        
}  
	public void changePagetoCreat(GButton login,Controller c1)  
{  
        login.pageOption.controller = c1;
        //login.pageOption.index = 1; //通过索引设置
        //c1.setSelectedIndex(1);
        c1.SetSelectedIndex(1);
        //login.pageOption.name = "page_name"; //或通过页面名称设置
        
}  
	public void random(GTextField randomShow){
		S = Random.Range(1, 10);
		P = Random.Range(1, 10);
		D = Random.Range(1, 10);
		A = Random.Range(1, 10);
		I = Random.Range(1, 10);
		//Debug.Log(S);
		randomShow.text = string.Format("力量：{0}\n体质：{1}\n耐力：{2}\n敏捷：{3}\n智力：{4}\n", S, P, D, A, I);

	}
	public void startGame(){
		
		name = creatname.text;

		Debug.Log(playerlogin.instance.thisuser.ObjectId);
		playerlogin.instance.heroData(playerlogin.instance.thisuser.ObjectId);
		CloudManager.instance.readHeroData(playerlogin.instance.thisuser.ObjectId);
		HeroStatus.instance.UpdateAttribute();
		changePagetoMain(login, c1);
	}

	void OnKeyDown(EventContext context)
    {
        if (context.inputEvent.keyCode == KeyCode.Escape)
        {
            Application.Quit();
        }
    }



	//void OnKeyDown(EventContext context)
	//{
	//	if (context.inputEvent.keyCode == KeyCode.Escape)
	//	{
	//		Application.Quit();
	//	}
	//}
}