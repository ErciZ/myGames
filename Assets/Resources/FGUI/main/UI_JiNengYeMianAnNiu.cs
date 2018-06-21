/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_JiNengYeMianAnNiu : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm2x";

		public static UI_JiNengYeMianAnNiu CreateInstance()
		{
			return (UI_JiNengYeMianAnNiu)UIPackage.CreateObject("main","技能页面按钮");
		}

		public UI_JiNengYeMianAnNiu()
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