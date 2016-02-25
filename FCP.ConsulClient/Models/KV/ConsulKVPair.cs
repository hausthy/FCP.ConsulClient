namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul key/value
    /// </summary>
    public class ConsulKVPair
    {
        public string Key { get; set; }
       
        public ulong CreateIndex { get; set; }
       
        public ulong ModifyIndex { get; set; }
        
        public ulong LockIndex { get; set; }

        public ulong Flags { get; set; }
        public string Value { get; set; }
        public string Session { get; set; }
    }
}
