using UnityEngine;
using FairyGUI;

public class VirtualListMain : MonoBehaviour
{
	GComponent _mainView;
	GList _list;

	void Awake()
	{
		UIPackage.AddPackage("FGUI/main");
		UIObjectFactory.SetPackageItemExtension("ui://main/mailItem", typeof(MailItem));
        //_mainView = this.GetComponent<UIPanel>().ui;

        //_list = _mainView.GetChild("mailList").asList;

        //_list.SetVirtualAndLoop();
        //_list.itemRenderer = RenderListItem;
        //_list.numItems = 50;
	}

	void Start()
	{
		Application.targetFrameRate = 60;
		//Stage.inst.onKeyDown.Add(OnKeyDown);

		_mainView = this.GetComponent<UIPanel>().ui;

		_list = _mainView.GetChild("mailList").asList;
        //_list.SetVirtual();
        _list.SetVirtualAndLoop();

		_list.itemRenderer = RenderListItem;
		_list.numItems = 50;
	}

	public void RenderListItem(int index, GObject obj)
	{
		MailItem item = (MailItem)obj;
        //Debug.Log("index"+index);
        item.setText(index+"");
	}

    public void ChangeListItem(int index, GObject obj,string str)
    {
        MailItem item = (MailItem)obj;
        item.setText(index + str);
    }

  
	//void OnKeyDown(EventContext context)
	//{
	//	if (context.inputEvent.keyCode == KeyCode.Escape)
	//	{
	//		Application.Quit();
	//	}
	//}
}