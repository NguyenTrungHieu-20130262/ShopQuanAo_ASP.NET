namespace LT.NET_project_cuoiki.Models
{
    public class ProductEntity
    {
        int id;
        int id_category;
        string category;
        string title, keyword;
        int price;
        string size;
        string thumbnail;
        string description;
        int quantity;
        int is_on_sale;
        string status;
        string color;
        string img_link;

        public int Id { get => id; set => id = value; }
        public int Id_category { get => id_category; set => id_category = value; }
        public string Category { get => category; set => category = value; }
        public string Title { get => title; set => title = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public int Price { get => price; set => price = value; }
        public string Size { get => size; set => size = value; }
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Is_on_sale { get => is_on_sale; set => is_on_sale = value; }
        public string Status { get => status; set => status = value; }
        public string Color { get => color; set => color = value; }
        public string Img_link { get => img_link; set => img_link = value; }
        

        public ProductEntity(int id, string category, string title, string keyword, int price, string size, string thumbnail, string description, int quantity, int is_on_sale)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Keyword = keyword;
            this.Price = price;
            this.Size = size;
            this.Thumbnail = thumbnail;
            this.Description = description;
            this.Quantity = quantity;
            this.Is_on_sale = is_on_sale;
        }

        public ProductEntity(int id, string category, string title, int price, string size, string thumbnail, string description, int quantity)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Price = price;
            this.Size = size;
            this.Thumbnail = thumbnail;
            this.Description = description;
            this.Quantity = quantity;
        }

        public ProductEntity()
        {
        }

        public ProductEntity(int id, int id_category, string title, string thumbnail, int quantity, string status, int price, string category)
        {
            this.id = id;
            this.id_category = id_category;
            this.category = category;
            this.title = title;
            this.price = price;
            this.thumbnail = thumbnail;
            this.quantity = quantity;
            this.status = status;
        }

        public ProductEntity(int id, int id_category, string category, string title, string keyword, int price, string size, string description, int quantity, string color, string img_link)
        {
            this.id = id;
            this.id_category= id_category;
            this.category = category;
            this.title = title;
            this.keyword = keyword;
            this.price = price;
            this.size = size;
            this.description = description;
            this.quantity = quantity;
            this.color = color;
            this.img_link = img_link;
          
        }



    }
}