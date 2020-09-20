using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Usage: SomeStaticMethodClass.SomeStaticFunction()

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public class StateMachine
{
    private IState currentState;
    private Dictionary<System.Type, IState> states = new Dictionary<System.Type, IState>();

    public void OnStart()
    {
        //    AddState(new MenuState(this));
        //    AddState(new GameState(this));
        //    AddState(new )
        //
    }

    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }

    public void SwitchState(System.Type type)
    {
        currentState?.OnExit();
        currentState = states[type];
        currentState?.OnEnter();
    }

    public void AddState(IState state)
    {
        states.Add(state.GetType(), state);
    }
}

public abstract class State : IState
{
    public State(StateMachine owner)
    {
        this.owner = owner;
    }
    protected StateMachine owner;
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}