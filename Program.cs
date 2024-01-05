using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

var username = "dom051902.lab";
var password = "Control123";

DirectoryContext context = new DirectoryContext(DirectoryContextType.Forest,username,password);
Domain domain = Domain.GetDomain(context);

Console.WriteLine(domain.Name);

foreach(Domain child in domain.Children) {
    Console.WriteLine($"child domain : {child.Name}");
}