using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState _currentState; // current state
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>(); // all transitions
    private List<Transition> _currentTransitions = new List<Transition>(); // all transitions of the current state
    private List<Transition> _anyTransitions = new List<Transition>(); // all transitions of the any state
    private static List<Transition> EmptyTransitions = new List<Transition>(0); // empty transition

    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To);

        _currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if (state == _currentState)
            return;

        _currentState?.OnExit();
        _currentState = state;

        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
        if (_currentTransitions == null)
            _currentTransitions = EmptyTransitions;

        _currentState.OnEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var trans) == false)
        {
            trans = new List<Transition>();
            _transitions[from.GetType()] = trans;
        }

        trans.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public Func<bool> Condition { get; }
        public IState To { get; }

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition()
    {
        foreach (var trans in _anyTransitions)
        {
            if (trans.Condition())
            {
                return trans;
            }
        }

        foreach (var trans in _currentTransitions)
        {
            if (trans.Condition())
            {
                return trans;
            }
        }

        return null;
    }
}
