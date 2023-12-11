using Avro.Specific;

namespace Avro.Shared.Contracts;

public class EventX : ISpecificRecord
{

    private string _Title;
    private object _Event;

    public static Avro.Schema _SCHEMA = Avro.Schema.Parse(
        "{\"type\":\"record\",\"name\":\"EventX\",\"namespace\":\"Avro.Shared\",\"fields\":[{\"name\":\"Title\",\"type\":\"string\",\"displayName\":\"Title\",\"maxLength\":100},{\"name\":\"Event\",\"type\":[{\"type\":\"record\",\"name\":\"EventA\",\"fields\":[{\"name\":\"DataA\",\"type\":\"string\",\"displayName\":\"DataA\",\"maxLength\":100}],\"displayName\":\"EventA\"},{\"type\":\"record\",\"name\":\"EventB\",\"fields\":[{\"name\":\"DataB\",\"type\":\"string\",\"displayName\":\"DataB\",\"maxLength\":100}],\"displayName\":\"EventB\"}],\"displayName\":\"Event\"}]}");

    

    public virtual Schema Schema
    {
        get
        {
            return EventX._SCHEMA;
        }
    }

    public string Title
    {
        get
        {
            return this._Title;
        }
        set
        {
            this._Title = value;
        }
    }
    
    public object Event
    {
        get
        {
            return this._Event;
        }
        set
        {
            this._Event = value;
        }
    }
    
    
    public virtual object Get(int fieldPos)
    {
        switch (fieldPos)
        {
            case 0: return this._Title;
            case 1: return this.Event;
            default: throw new AvroRuntimeException("Bad index " + fieldPos+ " in Get()");
        }
    }

    public virtual void Put(int fieldPos, object fieldValue)
    {
        switch (fieldValue)
        {
            case 0: this._Title = (string)fieldValue; break;
            case 1: this.Event = (object)fieldValue; break;
            default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
        }
    }

    
}