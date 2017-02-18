using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace MyStateMachine {
public class StateMachine : IStateMachine {

	public Dictionary<string,IState> statesAvailable { get; private set; }

	private IState _currentState;
	private ITransition _transition;

	public StateMachine(){
		statesAvailable = new Dictionary<string, IState>();
		// add states here
		IState firstState = new State();
		statesAvailable.Add ("FirstState", firstState);

		_currentState = statesAvailable["FirstState"];

		_currentState.OnExitState += ChangeState;
		_currentState.Enter ();
	}

	public void ChangeState(ITransition transition){
		_transition = transition;
		_transition.OnFinished += TransitionFinishedHandler;
		_transition.Begin ();
	}

	public void TransitionFinishedHandler() {
		_currentState.OnExitState -= ChangeState;

		_currentState = _transition.desireState;
		_currentState.OnExitState += ChangeState;

		_transition.OnFinished -= TransitionFinishedHandler;
		_transition = null;

		_currentState.Enter ();
	}

	void Update(){
		_currentState.Update ();
		if (_transition != null) {
			_transition.Update ();
		}
	}

}



public class State : IState {

	public void Update(){}
	public void FixedUpdate (){	}

	public  void Enter  (){
		//OnExitState (...);  
	}
	private void _Exit  (){}

	public event ChangeState OnExitState;
}

public class Transition : ITransition {
	public Transition (IState desireState) { this.desireState = desireState; }
	public IState desireState { get; private set; }

	public void Update()	 {}
	public void FixedUpdate(){}

	public void Begin() {OnFinished ();}
	public event TransitionFinishedHandler OnFinished;
}

//} // End namespace