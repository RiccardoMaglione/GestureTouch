﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaglioneFramework
{
    public class GestureManager : MonoBehaviour
    {
        #region Variables
        #region Tap Variables
        int TouchCounter = 0;
        int TouchCounter1 = 0;
        float Timer = 0;
        float WaitTime = 0.5f;
        bool isFinishDouble = false;
        bool isFinishTriple = false;

        public delegate void DelegateTap();
        public DelegateTap MethodDoubleTap;
        public DelegateTap MethodTripleTap;
        #endregion
        #region Swipe Variables
        Vector3 InitialPosTouchSwipe;
        Vector3 MovedPosTouchSwipe;
        Vector3 DirectionTouchSwipe;

        public delegate void DelegateSwipe();
        public DelegateSwipe MethodUpSwipe;
        public DelegateSwipe MethodDownSwipe;
        public DelegateSwipe MethodRightSwipe;
        public DelegateSwipe MethodLeftSwipe;
        #endregion
        #region Long Press Variables
        float LongTimer = 0f;
        float LongWait = 3f;
        public delegate void DelegateLongPress();
        public DelegateLongPress MethodOneLongPress;
        public DelegateLongPress MethodTwoLongPress;
        bool CanSwipe = true;
        #endregion


        #endregion

        private void Start()
        {
            InitializeDelegate();
        }

        #region Initialization Method
        public void InitializeDelegate()
        {
            MethodDoubleTap = Jump;
            //MethodTripleTap == Method;

            //MethodUpSwipe = Method;
            //MethodDownSwipe = Method;
            MethodRightSwipe = PanelInfoRight;
            MethodLeftSwipe = PanelInfoLeft;

            //MethodOneLongPress = Method;
            //MethodTwoLongPress = Method;
        }
        #endregion

        private void Update()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Menu")
            {
                Touch TouchDetect = Input.GetTouch(0);
                if (TouchDetect.position.x > Screen.width / 2)
                {
                    Swipe();
                }

            }
            if (scene.name == "Second")
            {
                Timer += Time.deltaTime;
                Touch TouchDetect = Input.GetTouch(0);
                if (TouchDetect.position.x > Screen.width / 2)
                {
                    DoubleTap(MethodDoubleTap);
                }
                print(Timer);
                print(TouchCounter);
            }
            //if (scene.name == "Third")
            //{
            //    Touch TouchDetect = Input.GetTouch(0);
            //    if (TouchDetect.phase == TouchPhase.Began)
            //    {
            //        LongTimer = 0;
            //        print(LongTimer);
            //    }
            //    print(LongTimer);
            //    LongTimer += Time.deltaTime;
            //    OneLongPressFingerInterrupt(MethodOneLongPress);
            //}
        }


        #region Gesture Method
        #region Swipe - Four Direction
        public void Swipe()
        {
            if (Input.touchCount == 1)
            {
                Touch TouchSwipe = Input.GetTouch(0);
                print("£SDa");
                switch (TouchSwipe.phase)
                {
                    case TouchPhase.Began:
                        InitialPosTouchSwipe = TouchSwipe.position;
                        break;
                    case TouchPhase.Moved:
                        break;
                    //case TouchPhase.Stationary:
                    //    break;
                    case TouchPhase.Ended:
                        MovedPosTouchSwipe = TouchSwipe.position;
                        DirectionTouchSwipe = CalculateDirectionTouch(InitialPosTouchSwipe, MovedPosTouchSwipe);
                        break;
                    //case TouchPhase.Canceled:
                    //    break;
                    default:
                        break;
                }
                //ChooseUpDirectionTouch(DirectionTouchSwipe, MethodUpSwipe);
                //ChooseDownDirectionTouch(DirectionTouchSwipe, MethodDownSwipe);
                ChooseRightDirectionTouch(DirectionTouchSwipe, MethodRightSwipe);
                ChooseLeftDirectionTouch(DirectionTouchSwipe, MethodLeftSwipe);
                DirectionTouchSwipe = Vector3.zero;
            }
        }
        #endregion
        #region Tap - Double and Triple
        void DoubleTap(DelegateTap MethodDoubleTap)
        {
            if (Input.touchCount >= 1)                                  //Rilevo il primo tocco
            {
                Touch Touch1 = Input.GetTouch(0);                       //Prendo il primo tocco per sfruttare la funzionalità delle fasi
                if (Touch1.position.x > Screen.width / 2)
                {
                    if (Touch1.phase == TouchPhase.Began)                   //Il primo istante in cui tocco
                    {
                        TouchCounter1 = 1;                                   //Segno il contatore a 1 per indicare 1 tocco
                    }
                    if (Touch1.phase == TouchPhase.Ended)
                    {
                        isFinishDouble = true;
                        Timer = 0;
                    }
                    if (TouchCounter1 == 1)
                    {

                        if (Timer <= WaitTime && Input.touchCount >= 1 && isFinishDouble == true)
                        {
                            isFinishDouble = false;
                            Timer = 0;
                            TouchCounter1 = 0;
                            MethodDoubleTap();
                            print("Ciao" + TouchCounter1);
                        }
                        else
                        {
                            isFinishDouble = false;
                            Timer = 0;
                            TouchCounter1 = 0;
                        }
                    }
                }
            }
        }
        void TripleTap(DelegateTap MethodTripleTap)
        {
            if (Input.touchCount == 1)
            {
                Touch Touch1 = Input.GetTouch(0);
                if (Touch1.phase == TouchPhase.Began)                   //Il primo istante in cui tocco
                {
                    TouchCounter = 1;                                   //Segno il contatore a 1 per indicare 1 tocco
                }
                if (Touch1.phase == TouchPhase.Ended)
                {
                    isFinishTriple = true;
                    Timer = 0;
                }
            }
            switch (TouchCounter)
            {
                case 1:
                    Timer += Time.deltaTime;
                    if (Timer <= WaitTime && Input.touchCount == 1 && isFinishTriple == true)
                    {
                        isFinishTriple = false;
                        Touch Touch1 = Input.GetTouch(0);
                        if (Touch1.phase == TouchPhase.Began)
                        {
                            TouchCounter = 2;
                        }
                        if (Touch1.phase == TouchPhase.Ended)
                        {
                            isFinishTriple = true;
                            Timer = 0;
                        }
                    }
                    else
                    {
                        Timer = 0;
                        TouchCounter = 0;
                        isFinishTriple = false;
                    }
                    break;
                case 2:
                    Timer += Time.deltaTime;
                    if (Timer <= WaitTime && Input.touchCount == 2 && isFinishTriple == true)
                    {
                        Timer = 0;
                        TouchCounter = 0;
                        MethodTripleTap();
                    }
                    else
                    {
                        Timer = 0;
                        TouchCounter = 0;
                        isFinishTriple = false;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region LongPress
        //public void OneLongPressFinger(DelegateLongPress MethodOneLongPress)
        //{
        //    if(Input.touchCount == 1)
        //    {
        //        LongTimer += Time.deltaTime;
        //        if(LongTimer >= LongWait)
        //        {
        //            //LongTimer = 0;
        //            {
        //                print("Hey");
        //                MethodOneLongPress();
        //            }
        //        }
        //    }
        //}
        //public void OneLongPressFingerInterrupt(DelegateLongPress MethodOneLongPress)
        //{
        //    if (Input.touchCount == 1)
        //    {
        //        Touch Touch1 = Input.GetTouch(0);
        //        LongTimer += Time.deltaTime;
        //        if (Touch1.phase == TouchPhase.Ended)
        //        {
        //            MethodOneLongPress();
        //        }
        //    }
        //}
        //public void TwoLongPressFinger(DelegateLongPress MethodTwoLongPress)
        //{
        //    if (Input.touchCount == 2)
        //    {
        //        LongTimer += Time.deltaTime;
        //        if (LongTimer >= LongWait)
        //        {
        //            LongTimer = 0;
        //            {
        //                MethodTwoLongPress();
        //            }
        //        }
        //    }
        //}
        #endregion
        #endregion

        #region General Function and Method
        public Vector3 CalculateDirectionTouch(Vector3 InitialPos, Vector3 EndedPos)
        {
            Vector3 DirectionVectorTouch = (EndedPos - InitialPos).normalized;
            return DirectionVectorTouch = new Vector3(Mathf.Round(DirectionVectorTouch.x), Mathf.Round(DirectionVectorTouch.y), 0);
        }

        public void ChooseUpDirectionTouch(Vector3 DirectionVectorTouch, DelegateSwipe MethodUpSwipe)
        {
            if (DirectionVectorTouch == Vector3.up)
            {
                print("Choose: Vector3 Up");
                MethodUpSwipe();
            }
        }
        public void ChooseDownDirectionTouch(Vector3 DirectionVectorTouch, DelegateSwipe MethodDownSwipe)
        {
            if (DirectionVectorTouch == Vector3.down)
            {
                print("Choose: Vector3 Down");
                MethodDownSwipe();
            }
        }
        public void ChooseRightDirectionTouch(Vector3 DirectionVectorTouch, DelegateSwipe MethodRightSwipe)
        {
            if (DirectionVectorTouch == Vector3.right)
            {
                print("Choose: Vector3 Right");
                MethodRightSwipe();
            }
        }
        public void ChooseLeftDirectionTouch(Vector3 DirectionVectorTouch, DelegateSwipe MethodLeftSwipe)
        {
            if (DirectionVectorTouch == Vector3.left)
            {
                print("Choose: Vector3 Left");
                MethodLeftSwipe();
            }
        }
        #endregion

        public void Jump()
        {
            if (PlayerManager.isGrounded == true)
            {
                PlayerManager.rb.AddForce(Vector2.up * PlayerManager.jumpForce, ForceMode.Impulse);
                PlayerManager.isGrounded = false;
            }
        }
        public void PanelInfoLeft()
        {
            if (CanSwipe == true)
            {
                Info.InfoPanel.transform.position = new Vector2(Info.EndPointRightStatic.transform.position.x, Info.InfoPanel.transform.position.y);
                LongTimer = 0;
                CanSwipe = false;
            }
        }
        public void PanelInfoRight()
        {
            if (CanSwipe == false)
            {
                Info.InfoPanel.transform.position = new Vector2(Info.EndPointLeftStatic.transform.position.x, Info.InfoPanel.transform.position.y);
                LongTimer = 0;
                CanSwipe = true;
            }
        }
    }
}