using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayItemInfo : MonoBehaviour
{
        [SerializeField] private TextMeshPro title, discription;

        private void OnMouseEnter() {
            title.enabled = true;
        }
        private void OnMouseExit() {
            title.enabled = false;
        }
        public void ShowDiscription(){
            discription.enabled = true;
        }        
        public void HideDiscription(){
            discription.enabled = false;
        }       
}
