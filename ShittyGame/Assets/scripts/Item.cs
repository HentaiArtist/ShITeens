﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
 public void ShowItem()
    {
        gameObject.SetActive(true)  ;
    }
    public void HideItem()
    {
        gameObject.SetActive(false);

    }
	
}
