namespace Photography.Web.Services
{
    using Photography.Data.UnitOfWork;

    public abstract class ServiceBase
    {
        protected ServiceBase(IPhotographyData data)
        {
            this.Data = data;
        }

        protected IPhotographyData Data { get; private set; }
    }
}