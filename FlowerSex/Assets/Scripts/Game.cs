using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using Random = System.Random;

public class Game : MonoBehaviour
{   /*
    //****************************************
    //*           Behavior Tree              *
    //****************************************
    private Tree<Game> _tree;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _tree = new Tree<Game>(new Sequence<Game>(new IsRaycastIn(),new Selector<Game>(
            // change the position once in a while
            new Sequence<Game>(
                new IsTimeChange(),
                new Selector<JumpEnemy_BT>(
                    new Sequence<JumpEnemy_BT>(new Not<JumpEnemy_BT>( new IsPlayerInRange()), new ChangeDirection()),
                    new Sequence<JumpEnemy_BT>(new IsPlayerInRange(), new ChangeDirectionToPlayer()))
            ),
            //
            new Sequence<JumpEnemy_BT>(new IsStopTime(), new Stop()),
            new Sequence<JumpEnemy_BT>( 
                new IsPlayerInRange(), 
                new Attack() // Attack
            ),

            new Walk()
        )));
    }

    
    // Update is called once per frame
    void Update()
    {
        _tree.Update(this);
        
    }
    
    //****************************************
    //*            Exact func                *
    //****************************************
    
    //****************************************
    //*             Condition                *
    //****************************************
    private class IsRaycastIn : Node<Game>
    {
        public override bool Update(Game game)
        {
            return true;
        }
    }
    private class IsTouching : Node<Game>
    {
        public override bool Update(Game game)
        {
            if (Input.touchCount != 0)
            {
                var _touch = Input.GetTouch(0);
            }
            
            return true;
        }
    }
    private class IsTouchStay : Node<Game>
    {
        public override bool Update(Game game)
        {
            return true;
        }
    }
    private class IsTouchDrag : Node<Game>
    {
        public override bool Update(Game game)
        {
            return true;
        }
    }
    */

    //****************************************
    //*           Gesture Event              *
    //****************************************    

    public GameObject InnerEar; //226, 223, 121
    public GameObject CenterEar; //192, 188, 136
    public GameObject TinyEar;  //229, 219, 84
    public GameObject BaseEar; //240,239,125

    void OnEnable(){
        EasyTouch.On_LongTap += On_LongTap;
        EasyTouch.On_Swipe += On_Swipe;
        EasyTouch.On_SimpleTap += On_SimpleTap;
    }
    
    void OnDisable(){
        UnsubscribeEvent();
    }
	
    void OnDestroy(){
        UnsubscribeEvent();
    }
	
    void UnsubscribeEvent(){
        EasyTouch.On_LongTap -= On_LongTap;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    void On_SimpleTap(Gesture gesture)
    {    
        if (gesture != null)
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(gesture.position);
            if (Physics2D.Raycast(test, (gesture.position)).collider.tag == "InnerEar")
            {
                InnerEar.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.89f, 0.87f, 0.47f);
            }
            else if (Physics2D.Raycast(test, (gesture.position)).collider.tag == "CenterEar") {
                CenterEar.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.73f, 0.53f);
            }

            else if (Physics2D.Raycast(test, (gesture.position)).collider.tag == "BaseEar")
            {
                BaseEar.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.90f, 0.86f, 0.33f);
            }

            else if (Physics2D.Raycast(test, (gesture.position)).collider.tag == "TinnyEar")
            {
                TinyEar.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.94f, 0.94f, 0.49f);
            }
        }
    }

    void On_Swipe(Gesture gesture)
    {
        Debug.Log("swipe");
    }

    void On_LongTap(Gesture gesture)
    {
        Debug.Log("longtap");
    }
}
