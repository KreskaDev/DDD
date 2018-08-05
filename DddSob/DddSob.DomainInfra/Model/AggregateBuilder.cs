namespace DddSob.DomainInfra.Model
{
    //public class AggregateBuilder
    //{
    //    public AggregateBuilder()
    //    {
    //        Identifier = null;
    //        ExpectedVersion = Int32.MinValue;
    //        Root = null;
    //    }
        
    //    internal AggregateBuilder(Aggregate instance)
    //    {
    //        Identifier = instance.Identifier;
    //        ExpectedVersion = instance.ExpectedVersion;
    //        Root = instance.Root;
    //    }

    //    public string Identifier { get; private set; }
    //    public int ExpectedVersion { get; private set; }
    //    public IAggregateRootEntity Root { get; private set; }
    //    public AggregateBuilder IdentifiedBy(string value)
    //    {
    //        Identifier = value;
    //        return this;
    //    }
        
    //    public AggregateBuilder ExpectVersion(int value)
    //    {
    //        ExpectedVersion = value;
    //        return this;
    //    }
        
    //    public AggregateBuilder WithRoot(IAggregateRootEntity value)
    //    {
    //        Root = value;
    //        return this;
    //    }
        
    //    public Aggregate Build()
    //    {
    //        return new Aggregate(Identifier, ExpectedVersion, Root);
    //    }
    //}
}