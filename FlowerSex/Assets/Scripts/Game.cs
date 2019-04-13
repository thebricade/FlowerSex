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

    
    void OnEnable(){
        EasyTouch.On_LongTap += On_LongTap;
        EasyTouch.On_Drag += On_Drag;
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
        EasyTouch.On_Drag -= On_Drag;
        EasyTouch.On_Swipe -= On_Swipe;
        EasyTouch.On_SimpleTap -= On_SimpleTap;
    }

    void On_SimpleTap(Gesture gesture)
    {
        Debug.Log("simpletap");
    }

    void On_Swipe(Gesture gesture)
    {
        Debug.Log("swipe");
    }

    void On_Drag(Gesture gesture)
    {
        Debug.Log("drag");
    }

    void On_LongTap(Gesture gesture)
    {
        Debug.Log("longtap");
    }
}
