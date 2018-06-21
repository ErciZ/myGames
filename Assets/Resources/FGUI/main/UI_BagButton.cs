/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_BagButton : GButton
	{
		public GMovieClip m_n2;
		public GImage m_n3;

		public const string URL = "ui://dt4ij9q6jd5v2h";

		public static UI_BagButton CreateInstance()
		{
			return (UI_BagButton)UIPackage.CreateObject("main","BagButton");
		}

		public UI_BagButton()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n2 = (GMovieClip)this.GetChild("n2");
			m_n3 = (GImage)this.GetChild("n3");
		}
	}
}