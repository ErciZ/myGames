using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

[Serializable]
public class DataType {

	[SerializeField]
	public int Id { get;  set; }


	public void setId(int Id)
    {
		this.Id = Id;
    }

//	public virtual void Default() {
//		
//	}

}
