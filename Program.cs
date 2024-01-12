
using System.DirectoryServices;
using Object;

public class Program {
    public static void Main(string []args) {
        string filter = "";
        int pageSize = 1000;
        string domainName = "dom051902.lab";
        using(ComputerCollector? collector = (ComputerCollector?)CollectorFactory.CreateCollectorFromType(CollectorTypes.Computer,domainName)) {
            foreach(Computer computer in collector.Collect(filter,pageSize)) {
                Console.WriteLine(computer.GetName());
            }
        }
    }
}