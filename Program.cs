using System.DirectoryServices;
using System.Security.Principal;

class Program {
    public static void Main(String []args) {
        var path = "LDAP://dom051902.lab";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
        DirectoryEntry directoryEntry = 
            new DirectoryEntry(
                path,username,password,AuthenticationTypes.Secure
            );
        DirectorySearcher searcher = new DirectorySearcher();
        searcher.SearchScope = SearchScope.Subtree;
        searcher.Filter = "(&(objectCategory=computer)(sAMAccountType=805306369))";
        searcher.PageSize = 1000;
        SearchResultCollection results = searcher.FindAll();
        foreach(SearchResult result in results) {
        	var objectSid = (byte [])(result.Properties["objectSid"][0]);
			var sid = new SecurityIdentifier(objectSid,0);
			var account = sid.Translate(typeof(NTAccount));
			Console.WriteLine(account.ToString());
        }
    }
}
