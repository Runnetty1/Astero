using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
namespace InventorySystem.Core
{
    public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [HideInInspector]
        public static GameObject itemBeingDragged;
        
        Vector3 startPosition;
        [HideInInspector]
        public Transform startParent;
        [HideInInspector]
        public enum DragState { SPLITDRAG, DRAG, IDLE, PLACEABLE }
        [HideInInspector]
        public DragState state = DragState.IDLE;
        [HideInInspector]
        public GameObject newSplitedItem;

        public void OnBeginDrag(PointerEventData eventData)
        {

            itemBeingDragged = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;

            GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.state = DragState.DRAG;
            if (Input.GetKey(KeyCode.LeftControl))
            {
                //splitStack

                int half = Mathf.FloorToInt(itemBeingDragged.GetComponent<Item>().Amount / 2f);
                if (half >= 1)
                {

                    //Debug.Log("spliting: half=" + half);
                    string help = itemBeingDragged.name.Contains("Clone") ? itemBeingDragged.name.Remove(itemBeingDragged.name.IndexOf("(Clone)")) : itemBeingDragged.name;

                    //LOAD the item and place in slot that we started in

                    Object pPrefab = Resources.Load("Items/"+help);
                    GameObject OB = (GameObject)GameObject.Instantiate(pPrefab, Vector3.zero, Quaternion.identity);

                    newSplitedItem = Instantiate(OB, itemBeingDragged.GetComponent<Item>().startPosition, Quaternion.identity);

                    newSplitedItem.transform.SetParent(startParent);
                    Debug.Log(OB + ", Parent: " + OB.transform.parent);
                    newSplitedItem.GetComponent<Item>().Amount = half;
                    itemBeingDragged.GetComponent<Item>().Amount -= half;
                    newSplitedItem.GetComponent<Item>().TextUpdate();
                    itemBeingDragged.GetComponent<Item>().TextUpdate();
                    this.state = DragState.SPLITDRAG;

                }
            }
            itemBeingDragged.transform.SetParent(GameObject.FindGameObjectWithTag("tempSlot").transform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (transform.parent == startParent)
            {
                //outside
                if (this.state == DragState.DRAG)
                {
                    itemBeingDragged = null;
                    //Debug.Log("not dropped on slot");
                    transform.position = startPosition;
                    transform.SetParent(startParent);

                }
                else if (this.state == DragState.SPLITDRAG)
                {
                    //merge back

                    int full = newSplitedItem.GetComponent<Item>().Amount + itemBeingDragged.GetComponent<Item>().Amount;
                    //Debug.Log("merging back: " + full);
                    itemBeingDragged.GetComponent<Item>().Amount = full;
                    itemBeingDragged.GetComponent<Item>().TextUpdate();
                    Destroy(newSplitedItem);
                    transform.position = startPosition;
                    //transform.parent = startParent;
                    newSplitedItem = null;
                    itemBeingDragged = null;
                }
            }
            else
            {
                //Debug.Log("o");
                if (this.state == DragState.SPLITDRAG)
                {
                    //merge back

                    int full = newSplitedItem.GetComponent<Item>().Amount + itemBeingDragged.GetComponent<Item>().Amount;
                    //Debug.Log("wat merging back: " + full);
                    itemBeingDragged.GetComponent<Item>().Amount = full;
                    itemBeingDragged.GetComponent<Item>().TextUpdate();
                    Destroy(newSplitedItem);
                    transform.position = startPosition;
                    //set parent back!
                    transform.SetParent(startParent);
                    newSplitedItem = null;
                    itemBeingDragged = null;
                }
                else if (this.state == DragState.PLACEABLE)
                {
                    //Debug.Log("trialer");

                    itemBeingDragged = null;
                }
                else if (this.state == DragState.DRAG)
                {
                    //Debug.Log("draging and no parent? " + itemBeingDragged.GetComponent<Item>().startParent.name);
                    itemBeingDragged.transform.SetParent(startParent);
                    Debug.Log("?");
                    itemBeingDragged = null;
                }
            }
            this.state = DragState.IDLE;

        }
    }
}