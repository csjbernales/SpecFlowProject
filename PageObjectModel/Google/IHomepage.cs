namespace PageObjectModel.Google
{
    public interface IHomepage : IObjectInterface
    {
        IWebElement SearchBox { get; set; }
    }
}