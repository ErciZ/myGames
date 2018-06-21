/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_JinHuaYeMianAnNiu : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm33";

		public static UI_JinHuaYeMianAnNiu CreateInstance()
		{
			return (UI_JinHuaYeMianAnNiu)UIPackage.CreateObject("main","进化页面按钮");
		}

		public UI_JinHuaYeMianAnNiu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetController("button");
			m_n1 = (GImage)this.GetChild("n1");
		}
	}
}