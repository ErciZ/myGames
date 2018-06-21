/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_RenWuYeMianAnNiu : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://dt4ij9q6s2nm31";

		public static UI_RenWuYeMianAnNiu CreateInstance()
		{
			return (UI_RenWuYeMianAnNiu)UIPackage.CreateObject("main","人物页面按钮");
		}

		public UI_RenWuYeMianAnNiu()
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