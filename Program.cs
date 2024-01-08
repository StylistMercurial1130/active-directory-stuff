using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

class Program {
    public static void Main(String []args) {
        // var path = "LDAP://dom051902.lab/CN=Computers";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
     
		DirectoryContext context = new DirectoryContext(DirectoryContextType.Forest,username,password);	
		Forest forest = Domain.GetDomain(context).Forest;

		DirectoryEntry de = forest.RootDomain.GetDirectoryEntry();

		Console.WriteLine(de.Name);
    }
}
