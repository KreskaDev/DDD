namespace DddSob.Contexts.NoRelation.Domain.Contexts.ContractorsDomain.ContractorsBC.Command
{
    public class AddCrontractorCommand
    {
        public AddCrontractorCommand(string name, string nip, string address)
        {
            Name = name;
            Nip = nip;
            Address = address;
        }

        public string Name { get; }
        public string Nip { get; }
        public string Address { get; }
    }
}