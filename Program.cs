using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

var domain = Domain.GetDomain(
    new DirectoryContext(
        DirectoryContextType.Domain,
        "dom051902.lab",
        "DOM051902\\Administrator","Control123")
);

