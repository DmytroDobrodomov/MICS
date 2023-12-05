using System.Net.Http;

/// <summary>
/// Browser can load get page text (from url) 
/// 
/// and save it to index.html to read it (only browser can do this, proxy can't!)
/// </summary>
public class SomeBrowser{
    public async Task GetPage(string url)
    {
        Console.WriteLine("Browser: Trying to get page...");
        using (HttpClient client = new HttpClient())
        {
            string HTMLText = await client.GetStringAsync(url);
            PageToFile(HTMLText);
        }
    }
    public void PageToFile(string HTMLText){
        using (StreamWriter outputFile = new StreamWriter("index.html"))
        {
            outputFile.WriteLine(HTMLText);
        }
        Console.WriteLine("Browser: Page loaded to index.html");
    }
}