using Object;

public enum CollectorTypes {
    Computer 
}

public class CollectorFactory {
    public static IADCollector? CreateCollectorFromType(CollectorTypes type,string domain) {
        switch(type) {
            case CollectorTypes.Computer : return new ComputerCollector(domain);            
        }
        return null;
    }
}