/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_JiangLiYeMianAnNiu : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm2z";

		public static UI_JiangLiYeMianAnNiu CreateInstance()
		{
			return (UI_JiangLiYeMianAnNiu)UIPackage.CreateObject("main","奖励页面按钮");
		}

		public UI_JiangLiYeMianAnNiu()
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