using System.DirectoryServices;
using System.Security.Principal;

class Program {
    public static void Main(String []args) {
        var path = "LDAP://dom051902.lab/CN=Computers";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
        DirectoryEntry directoryEntry = 
            new DirectoryEntry(
                path,username,password,AuthenticationTypes.Secure
            );
		foreach(DirectoryEntry child in directoryEntry.Children) {
			string computerName = child.Name;
			if(computerName != "") Console.WriteLine(computerName);
		}
    }
}
