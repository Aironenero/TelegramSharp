namespace TelegramSharp.Core.Utils
{
    public class MultiObject<K, V> {
        public K Object1 { get; set; }
        public V Object2 { get; set; }

        public MultiObject(K Object1, V Object2) {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public void SetObjects(K Object1, V Object2) {
            this.Object1 = Object1;
            this.Object2 = Object2;
        }

        public MultiObject() {
            this.Object1 = default(K);
            this.Object2 = default(V);
        }
    }
}