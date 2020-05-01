﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    int CurrentItemIndex;
    public List<Item> items;

    void Start()
    {

        items = new List<Item>();

    }

    public void ChangeItem()
    {
        if (items.Count == 0)
        {
            return;
        }

        items[CurrentItemIndex].HideItem();
        CurrentItemIndex++;
        if (CurrentItemIndex >= items.Count)
        {
            CurrentItemIndex = 0;
        }
        items[CurrentItemIndex].ShowItem();
    }

    public void Use()
    {
           if (items[CurrentItemIndex].tag == "Gun")
           {
               Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
               sht.Use();
           
           }
      //  if (items[CurrentItemIndex].tag == "GrapplingGun")
        //{
           // GrapplingGun gun = items[CurrentItemIndex].GetComponent<GrapplingGun>();
         //   gun.StartGrapple();


        //}


    }

       public void Enduse()
       {
           if (items[CurrentItemIndex].tag == "Gun")
           {
               Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
               sht.Enduse();
          

        }

     //   if (items[CurrentItemIndex].tag == "GrapplingGun")
     //   {
          //  GrapplingGun gun = items[CurrentItemIndex].GetComponent<GrapplingGun>();
         //   gun.StopGrapple();


    //    }


    }
   /*
       public void Reload()
       {
           if (items[CurrentItemIndex].tag == "Gun")
           {
               Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
               sht.TryReload();
           }
       }

       public void Aim()
       {
           if(items[CurrentItemIndex].tag == "Gun")
           {
               Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
               sht.Aiming();
           }
       }

       public void Notaim()
       {
           if (items[CurrentItemIndex].tag == "Gun")
           {
               Shooting sht = items[CurrentItemIndex].GetComponent<Shooting>();
               sht.Notaiming();
           }
       }
       */
        public void Add(GameObject Ytem)
        {

            Item item = Ytem.GetComponent<Item>();
            if (item == null)
                return;


            items.Add(item);
        }

    }























