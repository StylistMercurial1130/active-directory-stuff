
using System.DirectoryServices;
using Object;

public class Program {
    public static void Main(string []args) {
		const string ldapPath = "LDAP://dom051903.dom051901.lab/DC=dom051903,DC=dom051901,DC=lab";
		const string account = "Administrator";
		const string password = "Control123";
    	DirectoryEntry de = new DirectoryEntry(ldapPath,account,password,AuthenticationTypes.Secure); 
		try {
			object nativeObj = de.NativeObject;
		} catch(Exception ex) {
			throw new Exception(ex.ToString());
		}
    }
}
