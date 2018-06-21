/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_DuanZaoYeMianAnNiu : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm2y";

		public static UI_DuanZaoYeMianAnNiu CreateInstance()
		{
			return (UI_DuanZaoYeMianAnNiu)UIPackage.CreateObject("main","锻造页面按钮");
		}

		public UI_DuanZaoYeMianAnNiu()
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