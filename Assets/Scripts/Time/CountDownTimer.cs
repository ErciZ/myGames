using UnityEngine;
/// &lt;summary&gt;
/// 倒计时器。
/// &lt;/summary&gt;
public sealed class CountDownTimer
{
	public bool IsAutoCycle { get; private set; }
	// 是否自动循环（小于等于0后重置）
	public bool IsStoped { get; private set; }                     // 是否是否暂停了
	public float CurrentTime { get { return UpdateCurrentTime(); } }// 当前时间
	public bool IsTimeUp { get { return CurrentTime <= 0; } }       // 是否时间到
	public float Duration { get;  set; }                     // 计时时间长度
	private float lastTime;                                         // 上一次更新的时间
	private int lastUpdateFrame;                                    // 上一次更新倒计时的帧数（避免一帧多次更新计时）
	private float currentTime;                                      // 当前计时器剩余时间
																	/// &lt;summary&gt;
																	/// 构造倒计时器
																	/// &lt;/summary&gt;
																	/// &lt;param name="duration"&gt;起始时间&lt;/param&gt;
																	/// &lt;param name="autocycle"&gt;是否自动循环&lt;/param&gt;
	public CountDownTimer(float duration, bool autocycle = false, bool autoStart = true)
	{
		IsStoped = true;
		Duration = Mathf.Max(0f, duration);
		IsAutoCycle = autocycle;
		Reset(duration, !autoStart);
	}
	public CountDownTimer()
    {

    }
	/// &lt;summary&gt;
	/// 更新计时器时间
	/// &lt;/summary&gt;
	/// &lt;returns&gt;返回剩余时间&lt;/returns&gt;
	private float UpdateCurrentTime()
	{
		if (IsStoped || lastUpdateFrame == Time.frameCount)         // 暂停了或已经这一帧更新过了，直接返回
			return currentTime;
		if (currentTime <= 0)                                       // 小于等于0直接返回，如果循环那就重置时间
        {
			if (IsAutoCycle)
				Reset(Duration, false);
			return currentTime;
		}
		currentTime -= Time.time - lastTime;
		UpdateLastTimeInfo();
		return currentTime;
	}
	/// &lt;summary&gt;
	/// 更新时间标记信息
	/// &lt;/summary&gt;
	private void UpdateLastTimeInfo()
	{
		lastTime = Time.time;
		lastUpdateFrame = Time.frameCount;
	}
	/// &lt;summary&gt;
	/// 开始计时，取消暂停状态
	/// &lt;/summary&gt;
	public void Start()
	{
		Reset(Duration, false);
	}
	/// &lt;summary&gt;
	/// 重置计时器
	/// &lt;/summary&gt;
	/// &lt;param name="duration"&gt;持续时间&lt;/param&gt;
	/// &lt;param name="isStoped"&gt;是否暂停&lt;/param&gt;
	public void Reset(float duration, bool isStoped = false)
	{
		UpdateLastTimeInfo();
		Duration = Mathf.Max(0f, duration);
		currentTime = Duration;
		IsStoped = isStoped;
	}
	/// &lt;summary&gt;
	/// 暂停
	/// &lt;/summary&gt;
	public void Pause()
	{
		UpdateCurrentTime();    // 暂停前先更新一遍
		IsStoped = true;
	}
	/// &lt;summary&gt;
	/// 继续（取消暂停）
	/// &lt;/summary&gt;
	public void Continue()
	{
		UpdateLastTimeInfo();   // 继续前先更新当前时间信息
		IsStoped = false;
	}
	/// &lt;summary&gt;
	/// 终止，暂停且设置当前值为0
	/// &lt;/summary&gt;
	public void End()
	{
		IsStoped = true;
		currentTime = 0f;
	}
	/// &lt;summary&gt;
	/// 获取倒计时完成率（0为没开始计时，1为计时结束）
	/// &lt;/summary&gt;
	/// &lt;returns&gt;&lt;/returns&gt;
	public float GetPercent()
	{
		UpdateCurrentTime();
		if (currentTime <= 0 || Duration  <= 0)
            return 1f;
		return 1f - currentTime / Duration;
	}

}