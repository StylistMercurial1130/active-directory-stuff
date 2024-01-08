using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

class Program {
    public static void Main(String []args) {
        var path = "LDAP://dom051902.lab";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
        DirectoryEntry directoryEntry = 
            new DirectoryEntry(
                path,username,password,AuthenticationTypes.Secure
            );
		foreach(DirectoryEntry child in directoryEntry.Children) {
			Console.WriteLine(child.Name);		
		}	
    }
}
