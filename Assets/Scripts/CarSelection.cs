using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingCarMultiPlayer
{
    public class CarSelection : MonoBehaviour
    {
        private GameObject[] carList;
        private int index;

        private void Start()
        {
            index = PlayerPrefs.GetInt("CarSelected");
            carList = new GameObject[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                carList[i] = transform.GetChild(i).gameObject;
            }
            foreach (GameObject go in carList)
            {
                go.SetActive(false);
            }
            if (carList[index])
            {
                carList[index].SetActive(true);
            }
        }

        public void ToogleLeft()
        {
            carList[index].SetActive(false);
            index--;
            if(index<0)
            {
                index = carList.Length - 1;
            }
            carList[index].SetActive(true);

        }
        public void ToogleRight()
        {
            carList[index].SetActive(false);
            index++;
            if (index == carList.Length)
            {
                index = 0;
            }
            carList[index].SetActive(true);
        }

        public void CarSelect(Launcer launcer)
        {
            PlayerPrefs.SetInt("CarSelected", index);
            launcer.Connect();
        }

    }
}
