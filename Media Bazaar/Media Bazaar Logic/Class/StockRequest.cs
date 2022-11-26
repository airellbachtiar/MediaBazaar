namespace Media_Bazaar_Logic.Class
{
    public class StockRequest
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public State State { get; set; }
        public int StockDepotNeeded { get; set; }
        public int StockStoreNeeded { get; set; }

        public StockRequest(Product product, int stockDepotNeeded, int stockStoreNeeded)
        {
            this.Product = product;
            this.StockDepotNeeded = stockDepotNeeded;
            this.StockStoreNeeded = stockStoreNeeded;
            this.State = State.Open;
        }
        public StockRequest(int id, Product product, State state, int stockDepotNeeded, int stockStoreNeeded)
        {
            this.Id = id;
            this.Product = product;
            this.StockDepotNeeded = stockDepotNeeded;
            this.StockStoreNeeded = stockStoreNeeded;
            this.State = state;
        }
    }
}
