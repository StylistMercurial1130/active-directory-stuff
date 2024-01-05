using System.DirectoryServices.ActiveDirectory;

var domain = Domain.GetDomain(
    new DirectoryContext(
        DirectoryContextType.Domain,
        "dom051902.lab",
        "DOM051902\\Administrator","Control123")
);
Console.WriteLine(domain.Name);
foreach(DomainController domainController in domain.DomainControllers) {
    Console.WriteLine($"domain controllers : {domainController.Name}");
}
var forest = domain.Forest;
foreach(Domain dom in forest.Domains) {
    Console.WriteLine("domain : " + dom.Name);
}
