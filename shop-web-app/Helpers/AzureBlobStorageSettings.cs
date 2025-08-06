namespace shop_web_app.Helpers
{
    public class AzureBlobStorageSettings
    {
        public string ConnectionString { get; set; }
        public string PhotosContainerName { get; set; }
        public string ModelsContainerName { get; set; }
    }
}
