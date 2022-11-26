namespace Media_Bazaar_Logic.Class
{
    public class Product
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set { this.brand = value; }
        }

        private double length;
        public double Length
        {
            get { return length; }
            set { this.length = value; }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set { this.width = value; }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { this.height = value; }
        }

        private double sellingPrice;
        public double SellingPrice
        {
            get { return sellingPrice; }
            set { this.sellingPrice = value; }
        }

        private double priceWithoutVAT;
        public double PriceWithoutVAT
        {
            get { return priceWithoutVAT; }
            set { this.priceWithoutVAT = value; }
        }

        private int depotStock;
        public int DepotStock
        {
            get { return depotStock; }
            set { this.depotStock = value; }
        }

        private int storeStock;
        public int StoreStock
        {
            get { return storeStock; }
            set { this.storeStock = value; }
        }

        private string depotLocation;
        public string DepotLocation
        {
            get { return depotLocation; }
            set { this.depotLocation = value; }
        }

        private ProductCategory category;
        public ProductCategory Category
        {
            get { return category; }
            set { this.category = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }

        //id is null if you create this
        public Product(string name, string brand, double length, double width, double height,
            double sellingPrice, double priceWithoutVAT, int depotStock, int storeStock,
            string depotLocation, ProductCategory category, string description)
        {
            this.name = name;
            this.brand = brand;
            this.length = length;
            this.width = width;
            this.height = height;
            this.sellingPrice = sellingPrice;
            this.priceWithoutVAT = priceWithoutVAT;
            this.depotStock = depotStock;
            this.storeStock = storeStock;
            this.depotLocation = depotLocation;
            this.category = category;
            this.description = description;
        }

        //to assign id from database
        public Product(int id, string name, string brand, double length, double width, double height,
            double sellingPrice, double priceWithoutVAT, int depotStock, int storeStock,
            string depotLocation, ProductCategory category, string description)
        {
            this.id = id;
            this.name = name;
            this.brand = brand;
            this.length = length;
            this.width = width;
            this.height = height;
            this.sellingPrice = sellingPrice;
            this.priceWithoutVAT = priceWithoutVAT;
            this.depotStock = depotStock;
            this.storeStock = storeStock;
            this.depotLocation = depotLocation;
            this.category = category;
            this.description = description;
        }

        public string ToString()
        {
            return "Product[" + this.Id + ", " + this.name + ", " + this.brand + ", " + this.length + ", " +
                   this.width + ", " + this.height + ", " +
                   this.sellingPrice + ", " + this.priceWithoutVAT + ", " + this.depotStock + ", " + this.storeStock +
                   ", " + this.depotLocation + ", " + this.category.Name + ", " + this.description + "]";
        }

    }
}
