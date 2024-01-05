using System.DirectoryServices;

DirectoryEntry connection() {
    return new DirectoryEntry("LDAP://dom051902.lab","DOM051902\\Administrator","Control123",AuthenticationTypes.Secure);
}

var de = connection();

Console.WriteLine(de.Name);