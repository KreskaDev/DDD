using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace DddSob.DomainInfra.Model
{
    
    [Serializable]
    public class AggregateNotFoundException : AggregateSourceException
    {
        
        public AggregateNotFoundException(string identifier, Type clrType)
            : base(clrType != null && identifier != null
                    ? string.Format(CultureInfo.InvariantCulture, "Resources.AggregateNotFoundException_DefaultMessage", clrType.Name, identifier)
                    : null)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            ClrType = clrType ?? throw new ArgumentNullException(nameof(clrType));
        }
        
        public AggregateNotFoundException(string identifier, Type clrType, string message)
            : base(message)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            ClrType = clrType ?? throw new ArgumentNullException(nameof(clrType));
        }
        
        public AggregateNotFoundException(string identifier, Type clrType, string message, Exception innerException)
            : base(message, innerException)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            ClrType = clrType ?? throw new ArgumentNullException(nameof(clrType));
        }

        protected AggregateNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Identifier = info.GetString("identifier");
            ClrType = Type.GetType(info.GetString("clrType"), false);
        }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("identifier", Identifier);
            info.AddValue("clrType", ClrType.AssemblyQualifiedName);
        }
        
        public string Identifier { get; }
        
        public Type ClrType { get; }
    }
}