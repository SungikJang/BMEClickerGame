using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour {
    public enum ButtonEvent {
        ButtonDown,
        Clicked,
        Pressed,
        ButtonUp
    }
    public enum MouseEvent {
        PointerDown,
        Clicked,
        Pressed,
        PointerUp
    }
    public enum KeyBoardEvent {
        Clicked,
        Pressed,
        none
    }
    public enum UIEvent {
        Click,
        Drag,
    }
    public enum State {
        Die,
        Move,
        Idle,
        Skill
    }
    public enum MoveDir {
        Up,
        Down,
        Right,
        Left,
        None
    }
    public enum Scene {
        StartScene,
        JumpingScene,
        FortressScene,
        CurlingScene,
    }
}