public interface IPageUIController
{

    //LoadBar loadBar { get; }
    //CheckNetworkReachability checkNetworkReachability { get; }

    PageUI CurrentActivePage { get; }
    void SwitchPageOn<T>(params object[] parameters) where T : PageUI;
    void SwitchPageBack();
}
