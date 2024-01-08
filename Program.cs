using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

class Program {
    public static void Main(String []args) {
        var path = "dom051902.lab";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
     
		DirectoryContext context = new DirectoryContext(DirectoryContextType.Forest,path,username,password);	
		Forest forest = Domain.GetDomain(context).Forest;

		DirectoryEntry de = forest.RootDomain.GetDirectoryEntry();

		Console.WriteLine(de.Name);
    }
}
