namespace shop_web_app.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<IOrderRepository>> GetAllUserOrders();
    }
}
