using Avro.Specific;

namespace Avro.Shared.Contracts;

public class EventB : ISpecificRecord
{
    private string _DataB;
    public static Avro.Schema _SCHEMA =
        Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"EventB\",\"namespace\":\"Avro.Shared\",\"fields\":[{\"name\":\"DataB\",\"type\":\"string\",\"displayName\":\"DataB\",\"maxLength\":100}],\"displayName\":\"EventB\"}");



    public Schema Schema
    {
        get
        {
            return EventB._SCHEMA;
        }
    }
    
    public string DataB
    {
        get
        {
            return this._DataB;
        }
        set
        {
            this._DataB = value;
        }
    }
    
    public object Get(int fieldPos)
    {
        switch (fieldPos)
        {
            case 0: return this._DataB;
            default: throw new AvroRuntimeException("Bad index " + fieldPos+ " in Get()");
        }
    }

    public void Put(int fieldPos, object fieldValue)
    {
        switch (fieldValue)
        {
            case 0: this._DataB = (string)fieldValue; break;
            default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
        }
    }

    
}