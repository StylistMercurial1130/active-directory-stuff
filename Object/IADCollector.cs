using Object;

namespace Object {
    public interface IADCollector {
        public IEnumerable<ADObject> Collect(string Filter,int pageSize);
    }
}