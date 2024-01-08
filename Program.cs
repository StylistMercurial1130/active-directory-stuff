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
		
		adObjectsQueue.Enqueue(forest.RootDomain);

		while(adObjectsQueue.Count != 0) {
			Domain current = adObjectsQueue.Dequeue();	
			Console.WriteLine($"{current.Name} : children count : {current.Children.Count}");
			foreach(Domain dom in current.Children) {
				adObjectsQueue.Enqueue(dom);	
			}
			DirectoryEntry entry = current.GetDirectoryEntry();
			Console.WriteLine(entry.Properties.ToString());
		}
    }
}
