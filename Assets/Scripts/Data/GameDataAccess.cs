 using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class GameDataAccess{



	public Dictionary<System.Type, object> _allData = new Dictionary<System.Type, object>();
	// 添加单个数据表
	public void AddDataMap<T>(Dictionary<int, T> dict) where T : DataType
	{
		_allData[typeof(T)] = dict;
	}

	// 添加单个数据表
	public void AddDataMap<T>(ICollection list) where T : DataType
	{
		//Debug.Log("111111");
		Dictionary<int, T> dict = new Dictionary<int, T> ();
		//Debug.Log("222222");
		foreach (var v in list) {
			DataType dt = v as DataType;
			//Debug.Log("dt.id:"+dt.Id);
			dict.Add (dt.Id, (T)v);
		}
        //Debug.Log("2");
		AddDataMap (dict);
	}

	// 获取数据表
	public IEnumerable<T> GetDataMap<T>() where T : DataType
	{
		object obj = null;
		if (_allData.TryGetValue(typeof(T), out obj))
		{
			Dictionary<int, T> table = obj as Dictionary<int, T>;
			if (table != null)
			{
				return table.Values;
			}
		}
		return null;
	}

	// 获取单个数据
	public T GetData<T>(int id) where T : DataType
	{
		object obj = null;
		if (_allData.TryGetValue (typeof(T), out obj)) {
			Dictionary<int, T> table = obj as Dictionary<int, T>;
			if (table != null) {
				T dto = null;
				if (table.TryGetValue (id, out dto)) {
					return dto;
				}
			}
		} else {
			
		}
		return null;
	}

}
