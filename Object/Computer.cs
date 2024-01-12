using System.DirectoryServices;

namespace Object {
    public class Computer : ADObject {
        SearchResult props;
        public Computer(SearchResult props) {
            this.props = props;
        }

        public string GetName() {
            return (string)props.Properties["cn"][0];
        }
    }
}