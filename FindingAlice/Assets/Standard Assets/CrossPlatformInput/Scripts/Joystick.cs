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

        float MovementRange;
        public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
        public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
        public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input
        public string JoystickBtnName = "JoystickBtn"; // The name given to the vertical axis for the cross platform input

        Vector3 m_StartPos;
        bool m_UseX; // Toggle for using the x axis
        bool m_UseY; // Toggle for using the Y axis
        CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
        CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

        void OnEnable()
        {
            //CreateVirtualAxes();
        }

        private void Awake()
        {
            CreateVirtualAxes();
        }

        void Start()
        {
            MovementRange = transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x * 0.416f;
            m_StartPos = transform.position;
        }

        void UpdateVirtualAxes(Vector3 value)
        {
            var delta = m_StartPos - value;
            delta.y = -delta.y;
            delta /= MovementRange;
            if (m_UseX)
            {
                m_HorizontalVirtualAxis.Update(-delta.x);
            }

            if (m_UseY)
            {
                m_VerticalVirtualAxis.Update(delta.y);
            }
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
                newPos = Vector2.ClampMagnitude(data.position - new Vector2(m_StartPos.x, m_StartPos.y), MovementRange);
            }
            else if (m_UseX)
            {
                float delta = data.position.x - m_StartPos.x;
                delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
                newPos.x = delta;
            }
            else if (m_UseY)
            {
                float delta = data.position.y - m_StartPos.y;
                delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
                newPos.y = delta;
            }
            transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
            UpdateVirtualAxes(transform.position);
        }


        public void OnPointerUp(PointerEventData data)
        {
            transform.position = m_StartPos;
            UpdateVirtualAxes(m_StartPos);

            CrossPlatformInputManager.SetButtonUp(JoystickBtnName);
        }


        public void OnPointerDown(PointerEventData data)
        {
            CrossPlatformInputManager.SetButtonDown(JoystickBtnName);
        }

        void OnDisable()
        {
            transform.position = m_StartPos;
            CrossPlatformInputManager.SetButtonUp(JoystickBtnName);
            //// remove the joysticks from the cross platform input
            //if (m_UseX)
            //{
            //   m_HorizontalVirtualAxis.Remove();
            //}
            //if (m_UseY)
            //{
            //   m_VerticalVirtualAxis.Remove();
            //}
        }
    }
}