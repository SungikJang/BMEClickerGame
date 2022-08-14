using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {
    protected Animator _animator;

    protected Constant.State CharecterState = Constant.State.Idle;
    protected Constant.MoveDir _lastDir = Constant.MoveDir.Down;
    protected Constant.MoveDir _dir = Constant.MoveDir.Down;
    protected Vector3Int _cellPos = Vector3Int.zero;
    protected float _speed = 5.0f;
    public string SkillName = "";
    protected int CreatureId { get; set; }


    public Vector3Int CellPos {
        get { return _cellPos; }
        set {
            if (_cellPos == value) {
                return;
            }
            _cellPos = value;
        }
    }
    protected Constant.State State {
        get { return CharecterState; }
        set {
            if (CharecterState == value) {
                return;
            }
            CharecterState = value;
            UpdateAnimation();
        }
    }
    public Constant.MoveDir Dir {
        get { return _dir; }
        set {
            if (_dir == value) {
                return;
            }
            _dir = value;
            if (value != Constant.MoveDir.None) {
                _lastDir = value;
            }
        }
    }
    public Vector3Int GetFrontCellPosition() {
        Vector3Int result = CellPos + Vector3Int.down;
        switch (_lastDir) {
            case Constant.MoveDir.Up:
                result = CellPos + Vector3Int.up;
                break;
            case Constant.MoveDir.Down:
                result = CellPos + Vector3Int.down;
                break;
            case Constant.MoveDir.Left:
                result = CellPos + Vector3Int.left;
                break;
            case Constant.MoveDir.Right:
                result = CellPos + Vector3Int.right;
                break;
        }
        return result;
    }
    protected virtual void Move() {
        UpdateCreaturePosition();
    }
    protected virtual void Die() {
        State = Constant.State.Die;
    }
    protected virtual void Idle() {
        State = Constant.State.Idle;
    }
    protected virtual void Skill() {
        State = Constant.State.Skill;
    }
    public virtual void onDamaged() { }
    protected virtual void UpdateAnimation() {
        if (State == Constant.State.Idle) {
            Debug.Log(_lastDir);
            switch (_lastDir) {
                case Constant.MoveDir.Up:
                    _animator.Play("IDLE_BACK");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Down:
                    _animator.Play("IDLE_FRONT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Left:
                    _animator.Play("IDLE_RIGHT");
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Right:
                    _animator.Play("IDLE_RIGHT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
            }
        }
        else if (State == Constant.State.Move) {
            switch (_dir) {
                case Constant.MoveDir.Up:
                    _animator.Play("WALK_BACK");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    _lastDir = Constant.MoveDir.Up;
                    break;
                case Constant.MoveDir.Down:
                    _animator.Play("WALK_FRONT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    _lastDir = Constant.MoveDir.Down;
                    break;
                case Constant.MoveDir.Left:
                    _animator.Play("WALK_RIGHT");
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    _lastDir = Constant.MoveDir.Left;
                    break;
                case Constant.MoveDir.Right:
                    _animator.Play("WALK_RIGHT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    _lastDir = Constant.MoveDir.Right;
                    break;
            }
        }
        else if (State == Constant.State.Die) {

        }
        else if (State == Constant.State.Skill) {
            Debug.Log(SkillName);
            switch (_dir) {
                case Constant.MoveDir.Up:
                    _animator.Play(SkillName + "_BACK");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Down:
                    _animator.Play(SkillName + "_FRONT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Left:
                    _animator.Play(SkillName + "_RIGHT");
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    break;
                case Constant.MoveDir.Right:
                    _animator.Play(SkillName + "_RIGHT");
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    break;
            }
        }
    }
    void UpdateCreaturePosition() {
        // Vector3 destPos = Manager.Map.CurrentGrid.CellToWorld(CellPos) + new Vector3(0.5f, 0.5f, 0.0f);
        // Vector3 moveDir = destPos - transform.position;
        //
        // float dist = moveDir.magnitude;
        // if (dist < _speed * Time.deltaTime) {
        //     transform.position = destPos;
        // }
        // else {
        //     transform.position += moveDir.normalized * _speed * Time.deltaTime;
        // }
    }
    /*void UpdatePosition() {
        Vector3Int dest = CellPos;
        switch (_dir) {
            case Constant.MoveDir.Up:
                dest += Vector3Int.up;
                break;
            case Constant.MoveDir.Down:
                dest += Vector3Int.down;
                break;
            case Constant.MoveDir.Left:
                dest += Vector3Int.left;
                break;
            case Constant.MoveDir.Right:
                dest += Vector3Int.right;
                break;
        }
        if (Managers.Map.CanMove(dest) && (Managers.Obj.Find(dest) == null)) {
            CellPos = dest;
        }
        State = Constant.State.Idle;

    }*/
    protected virtual void UpdateController() {
        switch (State) {
            case Constant.State.Idle:
                Idle();
                break;
            case Constant.State.Move:
                Move();
                break;
            case Constant.State.Die:
                Die();
                break;
            case Constant.State.Skill:
                Skill();
                break;
        }
    }
    protected virtual void Init() {
        _animator = gameObject.GetComponent<Animator>();
        // transform.position = Manager.Map.CurrentGrid.CellToWorld(CellPos) + new Vector3(0.5f, 0.5f, 0.0f);
    }
    void Start() {
        Init();
    }
    void Update() {
        UpdateController();
    }
}