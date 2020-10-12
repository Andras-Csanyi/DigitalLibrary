namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities
{
    public class AddDomainObjectToAnotherDomainObjectsPropertyEntity
    {
        public string DomainObjectNameToBeAdded { get; set; }

        public string DomainObjectSource { get; set; }

        public string DomainObjectToBeAddedType { get; set; }

        public string TargetDomainObjectName { get; set; }

        public string TargetDomainObjectPropName { get; set; }

        public string TargetDomainObjectSource { get; set; }

        public string TargetDomainObjectType { get; set; }
    }
}