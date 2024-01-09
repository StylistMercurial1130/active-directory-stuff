using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;

class Program {
    public static void Main(String []args) {
        var path = "dom051902.lab";
        var username = "DOM051902\\Administrator"; 
        var password = "Control123";
     
		DirectoryContext context = new DirectoryContext(DirectoryContextType.Domain,path,username,password);	
		Forest forest = Domain.GetDomain(context).Forest;

		Queue<Domain> adObjectsQueue = new Queue<Domain>();
		List<DirectoryEntry> adObjects = new List<DirectoryEntry>();	
		adObjectsQueue.Enqueue(forest.RootDomain);

		while(adObjectsQueue.Count != 0) {
			Domain current = adObjectsQueue.Dequeue();	
			Console.WriteLine($"{current.Name} : children count : {current.Children.Count}");
			foreach(Domain dom in current.Children) {
				adObjectsQueue.Enqueue(dom);	
			}
			DirectoryEntry de = current.GetDirectoryEntry();
			adObjects.Add(de);
		}
		
		string filter = "$(&(objectCategory=computer)(sAMAccountType=805306369))";

		adObjects.ForEach(domain => {
			//DirectorySearcher searcher = new DirectorySearcher(domain);
			//searcher.SearchScope = SearchScope.Subtree;
			//searcher.Filter = filter;	
			//SearchResultCollection result = searcher.FindAll();
			//foreach(SearchResult res in result) {
				// Console.WriteLine(res.GetType().ToString());
			// }
			foreach(string propertyName in domain.Properties.PropertyNames) {
				Console.WriteLine(propertyName);
			}
		});
		
    }
}
