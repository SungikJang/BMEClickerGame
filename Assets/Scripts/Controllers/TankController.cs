using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : BaseController {
    // 매 프레임마다 자신의 상태를 재정의
    Coroutine _coroutine;


    void GetDirInput() {
        if (Input.GetKey(KeyCode.W)) {
            Dir = Constant.MoveDir.Up;
        }
        else if (Input.GetKey(KeyCode.S)) {
            Dir = Constant.MoveDir.Down;
        }
        else if (Input.GetKey(KeyCode.A)) {
            Dir = Constant.MoveDir.Left;
        }
        else if (Input.GetKey(KeyCode.D)) {
            Dir = Constant.MoveDir.Right;
        }
    }
    void GetSkillIput() {
        if (Input.GetKey(KeyCode.Space)) {
            State = Constant.State.Skill;
            _coroutine = StartCoroutine("CoroutineAttack");
        }
    }
    IEnumerator CoroutineAttack() {
        GameObject go = Manager.Obj.Find(GetFrontCellPosition());
        if(go != null) {

        }
        SkillName = "PUNCH";
        yield return new WaitForSeconds(1.0f);
        State = Constant.State.Idle;
    }
    private void ButtonEventHandler(Constant.ButtonEvent evt) {
        GetDirInput();
        switch (State) {
            case Constant.State.Die:
                break;
            case Constant.State.Move:
                ButtonEventHandler_Move(evt);
                break;
            case Constant.State.Idle:
                ButtonEventHandler_Idle(evt);
                break;
            case Constant.State.Skill:
                ButtonEventHandler_Skill(evt);
                break;
        }
        Dir = Constant.MoveDir.None;
    }
    private void ButtonEventHandler_Idle(Constant.ButtonEvent evt) {
        switch (evt) {
            case Constant.ButtonEvent.ButtonDown:
                Vector3Int destination = CellPos;
                switch (Dir) {
                    case Constant.MoveDir.Up:
                        destination += Vector3Int.up;
                        break;
                    case Constant.MoveDir.Down:
                        destination += Vector3Int.down;
                        break;
                    case Constant.MoveDir.Left:
                        destination += Vector3Int.left;
                        break;
                    case Constant.MoveDir.Right:
                        destination += Vector3Int.right;
                        break;
                }
                // if (Manager.Map.CanMove(destination) && (Manager.Obj.Find(destination) == null)) {
                //     State = Constant.State.Move;
                // }
                break;
            case Constant.ButtonEvent.Pressed:////있겠냐?ㅋ
                break;
            case Constant.ButtonEvent.ButtonUp://있겠냐?ㅋ
                break;
            case Constant.ButtonEvent.Clicked://클릭이 될수가 있겠냐?ㅋ ㅋ.ㅋ
                break;
        }
    }
    private void ButtonEventHandler_Move(Constant.ButtonEvent evt) {
        switch (evt) {
            case Constant.ButtonEvent.ButtonDown:
                break;
            case Constant.ButtonEvent.Pressed:
                // Vector3Int dest = CellPos;
                // switch (Dir) {
                //     case Constant.MoveDir.Up:
                //         dest += Vector3Int.up;
                //         break;
                //     case Constant.MoveDir.Down:
                //         dest += Vector3Int.down;
                //         break;
                //     case Constant.MoveDir.Left:
                //         dest += Vector3Int.left;
                //         break;
                //     case Constant.MoveDir.Right:
                //         dest += Vector3Int.right;
                //         break;
                // }
                // if (Manager.Map.CanMove(dest) && (Manager.Obj.Find(dest) == null)) {
                //     CellPos = dest;
                // }
                break;
            case Constant.ButtonEvent.ButtonUp:
                break;
            case Constant.ButtonEvent.Clicked:
                break;
        }
    }
    private void ButtonEventHandler_Skill(Constant.ButtonEvent evt) {
        Debug.Log("?");
        switch (evt) {
            case Constant.ButtonEvent.ButtonDown:
                break;
            case Constant.ButtonEvent.Pressed:
                break;
            case Constant.ButtonEvent.ButtonUp:
                break;
            case Constant.ButtonEvent.Clicked:
                break;
        }
    }
    protected override void Init() {
        base.Init();
        Manager.Input.ButtonAction -= ButtonEventHandler;
        Manager.Input.ButtonAction += ButtonEventHandler;
    }
    protected override void UpdateController() {
        switch (State) {
            case Constant.State.Idle:
                GetSkillIput();
                break;
            case Constant.State.Move:
                GetSkillIput();
                break;
            case Constant.State.Die:
                break;
            case Constant.State.Skill:
                break;
        }
        base.UpdateController();
    }
    private void LateUpdate() {
        //Camera.main.transform.position = transform.position;
    }
}
