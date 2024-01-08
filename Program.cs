using System.DirectoryServices;

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
        foreach(SearchResult value in results) {
            foreach(System.Collections.DictionaryEntry props in value.Properties) {
                Console.WriteLine(props.Key + ":" + value.Properties[props.Key.ToString()][0]);
            }
			Console.WriteLine();
        }
    }
}
