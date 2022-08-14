using System;
using UnityEngine;

public class InputManager {
    public Action<Constant.ButtonEvent> ButtonAction = null;
    public Action<Constant.MouseEvent> MouseAction = null;
    private bool MousePressed = false;
    private bool ButtonPressed = false;
    private float ButtonPressedTime;
    private float MousePressedTime;
    // Start is called before the first frame update
    public void Clear() {
        ButtonAction = null;
        ButtonPressed = false;
        ButtonPressedTime = 0;
        MousePressedTime = 0;
    }
    public void OnUpdate() {
        if ((ButtonAction != null)||(MouseAction != null)) {
            if (Input.GetMouseButton(1)) {
                if (MousePressed == false) {
                    MouseAction.Invoke(Constant.MouseEvent.PointerDown);
                    MousePressed = true;
                    MousePressedTime = Time.time;
                }
                else {
                    MouseAction.Invoke(Constant.MouseEvent.Pressed);
                }
            }
            else if (Input.anyKey) {
                if (ButtonPressed == false) {
                    ButtonAction.Invoke(Constant.ButtonEvent.ButtonDown);
                    ButtonPressed = true;
                    ButtonPressedTime = Time.time;
                }
                else {
                    ButtonAction.Invoke(Constant.ButtonEvent.Pressed);
                }
            }
            else {
                if (ButtonPressed == true) {
                    if (Time.time - ButtonPressedTime < 0.1f) {
                        ButtonAction.Invoke(Constant.ButtonEvent.Clicked);
                    }
                    else {
                        ButtonAction.Invoke(Constant.ButtonEvent.ButtonUp);
                    }
                    ButtonPressed = false;
                    ButtonPressedTime = 0;
                }
                if (MousePressed == true) {
                    if (Time.time - MousePressedTime < 0.1f) {
                        MouseAction.Invoke(Constant.MouseEvent.Clicked);
                    }
                    else {
                        MouseAction.Invoke(Constant.MouseEvent.PointerUp);
                    }
                    MousePressed = false;
                    MousePressedTime = 0;
                }
            }
        }
    }
}
