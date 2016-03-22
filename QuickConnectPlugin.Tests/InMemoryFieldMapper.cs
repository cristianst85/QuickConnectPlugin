
namespace QuickConnectPlugin.Tests {

    public class InMemoryFieldMapper : IFieldMapper {

        public string HostAddress { get; set; }
        public string ConnectionMethod { get; set; }
        public string AdditionalOptions { get; set; }
    }
}
