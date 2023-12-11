using Avro.Specific;

namespace Avro.Shared.Contracts;

public class EventA : ISpecificRecord
{
    private string _DataA;


    public static Avro.Schema _SCHEMA =
        Avro.Schema.Parse(
            "{\"type\":\"record\",\"name\":\"EventA\",\"namespace\":\"Avro.Shared\",\"fields\":[{\"name\":\"DataA\",\"type\":\"string\",\"displayName\":\"DataA\",\"maxLength\":100}],\"displayName\":\"EventA\"}");

    public virtual Schema Schema
    {
        get
        {
            return EventA._SCHEMA;
        }
    }


    public string DataA
    {
        get
        {
            return this._DataA;
        }
        set
        {
            this._DataA = value;
        }
    }
    
    
    
    public object Get(int fieldPos)
    {
        switch (fieldPos)
        {
            case 0: return this._DataA;
            default: throw new AvroRuntimeException("Bad index " + fieldPos+ " in Get()");
        }
    }

    public void Put(int fieldPos, object fieldValue)
    {
        switch (fieldValue)
        {
            case 0: this._DataA = (string)fieldValue; break;
            default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
        }
    }

    
}