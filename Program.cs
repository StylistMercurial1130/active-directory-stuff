using System.DirectoryServices;
using Microsoft.Win32;

var path = "GC://dom051902.lab";

try {
    using (var root = new DirectoryEntry(path,"DOM051902\\Administrator","Control123")) {
        Console.WriteLine(root.Name);
    }

} catch (DirectoryServicesCOMException) {

}
