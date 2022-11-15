using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public enum AxisOption
        {
            // Options for which axes to use
            Both, // Use both
            OnlyHorizontal, // Only horizontal
            OnlyVertical // Only vertical
        }

        [SerializeField] float MovementRange = 70f;

        public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
        public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
        public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input
        public string JoystickBtnName = "JoystickBtn"; // The name given to the vertical axis for the cross platform input

        Vector2 m_StartPosW;
        Vector2 m_StartPosL;
        bool m_UseX; // Toggle for using the x axis
        bool m_UseY; // Toggle for using the Y axis
        CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
        CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

        [Header("TestValue")]
        [SerializeField] Vector2 touchInputPos;
        [SerializeField] Vector2 joystickBtnPos;

        //void OnEnable()
        //{
        //    CreateVirtualAxes();
        //    //transform.localPosition = m_StartPosL;
        //}

        private void Awake()
        {
            CreateVirtualAxes();
        }

        void Start()
        {
            m_StartPosW = GetComponent<RectTransform>().position;
            m_StartPosL = GetComponent<RectTransform>().localPosition;
            MovementRange = GameObject.Find("Joystick").GetComponent<RectTransform>().sizeDelta.x;
            //MovementRange = transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x;
            //m_StartPos = GetComponent<RectTransform>().anchoredPosition;
        }

        void UpdateVirtualAxes(Vector2 value)
        {
            //
            var delta = m_StartPosW - value;
            delta.y = -delta.y;
            delta /= MovementRange;
            if (m_UseX)
            {
                m_HorizontalVirtualAxis.Update(-delta.x);
                //Debug.Log(m_HorizontalVirtualAxis.GetValue);
                //Debug.Log(m_HorizontalVirtualAxis.GetValueRaw);
            }

            if (m_UseY)
            {
                m_VerticalVirtualAxis.Update(delta.y);
            }

            //Debug.Log("Update");
        }

        void CreateVirtualAxes()
        {
            // set axes to use
            m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
            m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

            // create new axes based on axes to use
            if (m_UseX)
            {
                m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
                CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
            }
            if (m_UseY)
            {
                m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
                CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
            }
        }


        public void OnDrag(PointerEventData data)
        {
            Vector3 newPos = Vector3.zero;

            if (m_UseX && m_UseY)
            {
                newPos = Vector2.ClampMagnitude(data.position - new Vector2(m_StartPosW.x, m_StartPosW.y), MovementRange);
                //Debug.Log(data.position);
                //Debug.Log(new Vector2(m_StartPosW.x, m_StartPosW.y));
                joystickBtnPos = data.position;
                joystickBtnPos = new Vector2(m_StartPosW.x, m_StartPosW.y);
                //newPos = Vector2.ClampMagnitude(data.position - new Vector2(m_StartPosL.x, m_StartPosL.y), MovementRange);
            }
            else if (m_UseX)
            {
                float delta = data.position.x - m_StartPosW.x;
                //float delta = data.position.x - m_StartPosL.x;
                delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
                newPos.x = delta;
            }
            else if (m_UseY)
            {
                float delta = data.position.y - m_StartPosW.y;
                //float delta = data.position.y - m_StartPosL.y;
                delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
                newPos.y = delta;
            }
            //transform.position = new Vector3(m_StartPosW.x + newPos.x, m_StartPosW.y + newPos.y, m_StartPosW.z + newPos.z);
            transform.position = new Vector3(m_StartPosW.x + newPos.x, m_StartPosW.y + newPos.y/*, m_StartPosW.z + newPos.z*/);
            //transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
            //transform.localPosition = new Vector3(m_StartPosL.x + newPos.x, m_StartPosL.y + newPos.y, m_StartPosL.z + newPos.z);
            UpdateVirtualAxes(transform.position);
        }


        public void OnPointerUp(PointerEventData data)
        {
            //transform.localPosition = m_StartPosL;
            //transform.localPosition = m_StartPosW;
            transform.position = m_StartPosW;
            
            //
            UpdateVirtualAxes(m_StartPosW);

            CrossPlatformInputManager.SetButtonUp(JoystickBtnName);
        }


        public void OnPointerDown(PointerEventData data)
        {
            //Debug.Log(data.position);
            //Debug.Log(new Vector2(m_StartPosW.x, m_StartPosW.y));
            CrossPlatformInputManager.SetButtonDown(JoystickBtnName);
        }

        void OnDisable()
        {
            //transform.localPosition = m_StartPosL;
            //transform.localPosition = m_StartPosW;
            transform.position = m_StartPosW;
            CrossPlatformInputManager.SetButtonUp(JoystickBtnName);
            m_HorizontalVirtualAxis.Update(0);
            m_VerticalVirtualAxis.Update(0);
            // remove the joysticks from the cross platform input
            if (m_UseX)
            {
                m_HorizontalVirtualAxis.Remove();
            }
            if (m_UseY)
            {
                m_VerticalVirtualAxis.Remove();
            }
        }
    }
}