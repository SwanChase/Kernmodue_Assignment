using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float MoveSpeed
    {
        get; set;
    }



    // Start is called before the first frame update
    void Start()
    {
        DoSomething<Test>();
    }

    public T DoSomething<T>() where T : new()
    {
        return new T();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


public abstract class Singleton<T> : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
            else
            {
                Debug.Log("Two instances detected for singleton!");
            }
        }
    }
}

public class AudioManager : Singleton<AudioManager>
{
    void Awake()
    {
        Instance = this;
    }
}

public class SomeGenericClass<T>
{
    public T someGenericVariable;
    public T SomeGenericFunction<T>()
    {
        return default(T);
    }
}

//usage: new SomeGenericClass<float>();

public abstract class SomeAbstractClass<T>
{
    public Dictionary<T, float> someDictionary = new Dictionary<T, float>();

    public static float FindAValue(T key)
    {
        return someDictionary[key];
    }
    //This method has no body and MUST be overriden by childclasses
    public abstract void DoSomethingVeryCool();

    //This method has a base implementation
    public virtual void DoSomethingCool()
    {
        Debug.Log("Hello");
    }
}

public class SomeStaticMethodClass
{

    public static float someSharedFloat;

    public static void SomeStaticFunction()
    {

    }
}
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
        AddState(new IdleState(this));
        AddState(new AttackState(this));
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

 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void Start()
    {
        AudioManager.Instance.enabled = false;
    }
}

public interface IDamageable
{
    int Health { get; set; }
    void TakeDamage(int dam);
}

public abstract class ActorBase : IDamageable
{
    public ActorBase(int health)
    {
        Health = health;
    }

    public int Health { get; set; }

    public abstract void TakeDamage(int dam);

    public virtual void Move()
    {
        //Do some movement
    }
}

public class Player : ActorBase
{
    public Player(int health) : base(health)
    {

    }
    public override void TakeDamage(int dam)
    {
        Health -= dam;
    }
}

public class EnemyOne : ActorBase
{
    public EnemyOne(int health) : base(health)
    {
        Health *= 2;
    }

    public override void TakeDamage(int dam)
    {
        Health -= dam;
    }
}

public class Wall : IDamageable
{
    public int Health { get; set; }

    public Wall(int health)
    {
        Health = health;
    }

    public void TakeDamage(int dam)
    {
        Health -= dam;
    }
}