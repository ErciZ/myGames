/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_HeadBar : GProgressBar
	{
		public UI_bloodbar m_bar;
		public GTextField m_title;

		public const string URL = "ui://dt4ij9q6ukf03o";

		public static UI_HeadBar CreateInstance()
		{
			return (UI_HeadBar)UIPackage.CreateObject("main","HeadBar");
		}

		public UI_HeadBar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bar = (UI_bloodbar)this.GetChild("bar");
			m_title = (GTextField)this.GetChild("title");
		}
	}
}