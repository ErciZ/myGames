/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace main
{
	public partial class UI_WindowFrame : GLabel
	{
		public GImage m_n6;
		public GGraph m_dragArea;
		public GTextField m_title;
		public UI_CloseButton m_closeButton;

		public const string URL = "ui://dt4ij9q6jd5v2k";

		public static UI_WindowFrame CreateInstance()
		{
			return (UI_WindowFrame)UIPackage.CreateObject("main","WindowFrame");
		}

		public UI_WindowFrame()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n6 = (GImage)this.GetChild("n6");
			m_dragArea = (GGraph)this.GetChild("dragArea");
			m_title = (GTextField)this.GetChild("title");
			m_closeButton = (UI_CloseButton)this.GetChild("closeButton");
		}
	}
}