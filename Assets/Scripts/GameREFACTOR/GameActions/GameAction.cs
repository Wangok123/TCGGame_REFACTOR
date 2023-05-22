using GameREFACTOR;
using GameREFACTOR.Data;
using GameREFACTOR.Data.Cards;
using GameREFACTOR.GameActions;
using GameREFACTOR.Systems.Core;
using UnityEngine;

public class GameAction : MonoBehaviour
{
    public int Id { get; }
    public bool IsCanceled { get; protected set; }
    public Phase PreparePhase { get; protected set; }
    public Phase PerformPhase { get; protected set; }
    public Phase CancelPhase { get; protected set; }
    
    public int Priority { get; set; }
    public int OrderOfPlay { get; set; }
        
    public Player Player { get; set; }
        
    public Card SourceCard { get; set; }
    
    public GameAction()
    {
        Id = Global.GenerateId(GetType());
        PreparePhase = new Phase(this, OnPrepare);
        PerformPhase = new Phase(this, OnPerform);
        CancelPhase = new Phase(this, OnCancel);
    }

    public virtual void Cancel()
    {
        IsCanceled = true;
    }

    protected virtual void OnPrepare(IContainer gameState)
    {
        var eventName = Notification.Prepare(GetType());
        Global.Events.Publish(eventName, this);
    }

    protected virtual void OnPerform(IContainer gameState)
    {
        var eventName = Notification.Perform(GetType());
        Global.Events.Publish(eventName, this);
    }

    protected virtual void OnCancel(IContainer gameState)
    {
        var eventName = Notification.Cancel(GetType());
        Global.Events.Publish(eventName, this);
    }

    public override string ToString() => GetType().Name;
}
