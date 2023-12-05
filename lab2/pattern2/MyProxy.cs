public class ProxySavedPage{
    public string url;
    public int lifetime;
    public string HTMLText;

}
/// <summary>
/// Proxy can load page text to cache (big list)
/// Browser will be used to read it, so, proxy needs browser!
/// </summary>
public class MyProxy{
    public int pageLifetime;

    public List<ProxySavedPage> cache;

    public SomeBrowser browser;

    public MyProxy(SomeBrowser browserRef, int lifetime){
        browser = browserRef;
        this.pageLifetime = lifetime;
        cache = new List<ProxySavedPage>();
    }

    public ProxySavedPage SearchCache(string url){
        foreach(ProxySavedPage p in cache){
            if(p.url == url){
                return p;
            }
        }
        return null;
    }
    public async Task SavePageToCache(string url){
        if(SearchCache(url) != null) {
            Console.WriteLine("Error: Page is already exists in cache");
            return;
        }
        
        string HTMLText = "";
        Console.WriteLine("Proxy: Trying to get page...");
        using (HttpClient client = new HttpClient())
        {
            HTMLText = await client.GetStringAsync(url);
        }

        ProxySavedPage page = new();
        page.url = url;
        page.lifetime = pageLifetime;
        page.HTMLText = HTMLText;
        cache.Add(page);
        Console.WriteLine("Proxy: Saved page "+url+" to cache");
    }

    public async Task GetPage(string url){
        if(SearchCache(url) == null) {
            Console.WriteLine("Proxy: No page in cache. Trying to load...");
            await SavePageToCache(url);
        }
        else{
            Console.WriteLine("Proxy: Page found in cache. Loading...");
        }
        string HTMLText = SearchCache(url).HTMLText;
        browser.PageToFile(HTMLText);
        
    }

}