using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace InventorySystem.Core
{
    public class Stackable : Dragable
    {
        public bool isStackable;
        [SerializeField]
        private int amount = 1;
        public int Amount
        {
            set
            {
                amount = value;
                TextUpdate();
            }
            get { return amount; }
        }
        public int maxAmount;
        public Text amountText;

        // limit stack size
        public bool StackHasSpace(int toAdd)
        {
            return (this.Amount + toAdd) <= maxAmount;
        }


        public void AddToStack(Item item)
        {
            if (StackHasSpace(item.Amount))
            {
                this.Amount += item.Amount;

                TextUpdate();
            }
            else
            {
                Debug.Log("No space to add");
            }
            Destroy(item.gameObject);
        }

        public void TextUpdate()
        {
            this.amountText.text = Amount.ToString();
        }

        public bool IsFull
        {
            get
            {
                return Amount == maxAmount;
            }
        }

        public void ToppOffWith(Item itemStackToTopWith)
        {
            //this.
            //Motherfukking this.
            //mota fuckin bread crumbs.
            var remainder = maxAmount - Amount;
            itemStackToTopWith.Amount -= remainder;
            this.Amount += remainder;
        }
        public void RemoveItem()
        {

        }
        public virtual void Start()
        {
            this.amountText=transform.GetChild(0).gameObject.GetComponent<Text>();
            if (!isStackable)
            {
                if (amountText != null)
                {
                    this.amountText.gameObject.SetActive(false);
                }
            }
            else
            {
                if (amountText == null)
                {
                    //spawn textOBJ
                }
                if (amountText != null)
                {
                    this.amountText.gameObject.SetActive(true);
                }
                TextUpdate();
            }
        }
    }
}