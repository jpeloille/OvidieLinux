using System;

namespace Ovidie.Events;

public class EntityEventArgs<T> : EventArgs
{
    
    public T Entity { get; set; }
    public bool isNew { get; set; }

    public EntityEventArgs(T Entity, bool isNew)
    {
        this.Entity = Entity;
        this.isNew = isNew;
    }
}