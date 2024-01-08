using System.ComponentModel.DataAnnotations;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Cryptography;

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
        searcher.Filter = "&(objectCategory=computer)(userAccountControl:1.2.840.113556.1.4.803:=8192)(!primaryGroupID=521)";
        searcher.PageSize = 1000;
        SearchResultCollection results = searcher.FindAll();
        foreach(SearchResult value in results) {
            foreach(ResultPropertyCollection props in value.Properties) {
                Console.WriteLine(props.ToString());
            }
        }
    }
}
