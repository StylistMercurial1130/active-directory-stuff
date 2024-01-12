using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using Object;

public class ComputerCollector : IADCollector , IDisposable {
    Forest forest;

    public ComputerCollector(string domain) {
        DirectoryContext context = new(DirectoryContextType.Domain,domain);
        forest = Domain.GetDomain(context).Forest; 
    }

    public IEnumerable<ADObject> Collect(string filter,int pageSize) {
        Queue<Domain> domains = new Queue<Domain>();
        domains.Enqueue(forest.RootDomain);
        while (domains.Count != 0) {
            using (Domain dom = domains.Dequeue()) {
                foreach (Domain child in dom.Children)
                    domains.Enqueue(child);
                using (DirectorySearcher searcher = new(dom.GetDirectoryEntry())) {
                    searcher.Filter = filter;
                    searcher.PageSize = pageSize;
                    foreach (SearchResult result in searcher.FindAll()) {
                        yield return new Computer(result);            
                    }
                }
            }
        }
    }
    
    public void Dispose() {
        forest.Dispose();
    }
}