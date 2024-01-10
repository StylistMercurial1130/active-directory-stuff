using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;

class Program {
	public static List<DirectoryEntry> getComputers(string domainName) {
		DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://{domainName}");
		DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
		searcher.Filter = "(&(objectClass=computer)(sAMAccountType=805306369))";
		List<DirectoryEntry> computers = new List<DirectoryEntry>();		
		
		foreach(SearchResult result in searcher.FindAll()) {
			computers.Add(result.GetDirectoryEntry());
		}

		return computers;
	}	

	public static void SearchForest() {
		var path = "dom051902.lab";
		//var username = "DOM051902\\Administrator"; 
		//var password = "Control123";
		DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain,path);	
		Forest forest = Domain.GetDomain(context).Forest;

		Queue<Domain> adObjectsQueue = new Queue<Domain>();
		List<DirectoryEntry> adObjects = new List<DirectoryEntry>();	
		adObjectsQueue.Enqueue(forest.RootDomain);

		while(adObjectsQueue.Count != 0) {
			Domain current = adObjectsQueue.Dequeue();	
			foreach(Domain dom in current.Children) {
				adObjectsQueue.Enqueue(dom);	
			}
			ICollection<DirectoryEntry> computers = getComputers(current.Name); 
			adObjects.AddRange(computers);
		}

		adObjects.ForEach(computer => {
			Console.WriteLine($"computer : {computer.Name}");
			foreach(string propertyName in computer.Properties.PropertyNames) 
				Console.WriteLine($"propertyName : {propertyName} : value : {computer.Properties[propertyName][0]}");
			Console.WriteLine();
		});
	}

    public static void Main(String []args) {
        var path = "GC://dom051902.lab";
		var ldap_path = "LDAP://dom051902.lab";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
//		DirectoryEntry de = new DirectoryEntry(path,username,password,AuthenticationTypes.Secure);		
		string filter = "(&(objectClass=computer)(sAMAccountType=805306369))";
//		DirectorySearcher searcher = new DirectorySearcher(de);
//		searcher.Filter = filter;
//		searcher.SearchScope = SearchScope.Subtree;
//		foreach(SearchResult result in searcher.FindAll()) {
//			foreach(string props in result.Properties.PropertyNames) {
//				Console.WriteLine(props);
//			}
//		}
		DirectoryEntry ldap_de = new DirectoryEntry(ldap_path,username,password,AuthenticationTypes.Secure);
		DirectorySearcher ldap_searcher = new DirectorySearcher(ldap_de);
		ldap_searcher.SearchScope = SearchScope.Subtree;
		ldap_searcher.Filter = filter;
		foreach(SearchResult res in ldap_searcher.FindAll()) {
			foreach(string props in res.Properties.PropertyNames) {
				Console.WriteLine(props);
			}
		}
    }
}
