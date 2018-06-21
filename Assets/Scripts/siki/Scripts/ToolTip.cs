//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public class ToolTip : MonoBehaviour {

//    private Text toolTipText;//背景中显示的文本
//    private Text contentText;//显示的文本内容.Ps:因为背景中的内容会被遮罩,所以在背景的上面还有一个文本.
//    //第一个文本主要是为了控制背景的大小,第二个文本时为了显示内容.
//    private CanvasGroup canvasGroup;//控制ToolTip显示和隐藏的组件.

//    private float targetAlpha = 0 ;//目标值.0为隐藏.1为显示

//    public float smoothing = 1;//隐藏速度.

//    void Start()
//    {
//        toolTipText = GetComponent<Text>();
//        contentText = transform.Find("Content").GetComponent<Text>();
//        /// 这里报错,不能得到该组件,空指针.
//         //找到问题了,不要用transform.Find()方法,改用全局变量搜索方法.
//        canvasGroup = GetComponent<CanvasGroup>();
//    }

//    void Update()
//    {
//        if (canvasGroup.alpha != targetAlpha)//当当前值不等于目标值的时候,进行插值运算,渐变到目标值
//        {
//            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha,smoothing*Time.deltaTime);
//            //因为当前值不能达到目标值,为了节省内存,让差值小于一个数的时候就看作相等.
//            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
//            {
//                canvasGroup.alpha = targetAlpha;
//            }
//        }
//    }

//    public void Show(string text)//显示tooltip,text为显示的文本信息.

//    {
//        toolTipText.text = text;
//        contentText.text = text;
//        targetAlpha = 1;
//    }
//    public void Hide()//隐藏tooltip
//    {
//        targetAlpha = 0;
//    }
//    public void SetLocalPotion(Vector3 position)
//    {
//        transform.localPosition = position;
//        //注意!!!这里是localPosition 而不是position.
//    }
	
//}
