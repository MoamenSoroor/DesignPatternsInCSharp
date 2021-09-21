using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Patterns.Structural.ProxyPattern
{
    public class CachingProxy
    {

        public static void Test()
        {
            var proxy = new PageContentCachingProxy();

            string url = "https://en.wikipedia.org/wiki/Software_design_pattern";
            string page = proxy.GetPage(url);

            PrintPage(url, page);

            page = proxy.GetPage(url);
            
            PrintPage(url, page);


        }

        public static void PrintPage(string url, string str)
        {
            Console.WriteLine($"Page at URL: {url}");
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine(str);
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine();
        }


        //public static void TestPageContentCachingProxyWithCacheTimeout()
        //{
        //    using var proxy = new PageContentCachingProxyWithCacheTimeout();

        //    string url = "https://en.wikipedia.org/wiki/Software_design_pattern";
        //    string page = proxy.GetPage(url);

        //    PrintPage(url, page);


        //    // should get page from cache
        //    Thread.Sleep(2000);
        //    page = proxy.GetPage(url);
        //    PrintPage(url, page);



        //    // should get page from server
        //    Thread.Sleep(5000);
        //    page = proxy.GetPage(url);
        //    PrintPage(url, page);

        //}

    }

    public interface IPageContentGetter
    {
        string GetPage(string url);
    }

    public class PageContentGetter : IPageContentGetter
    {
        public string GetPage(string url)
        {
            Console.WriteLine("Getting page from server...");
            try
            {
                // Create a new WebClient instance.
                using (WebClient myWebClient = new WebClient())
                {
                    // Download the Web resource and save it into the current filesystem folder.
                    return myWebClient.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }


    public class PageContentCachingProxy : IPageContentGetter
    {
        private Dictionary<string, (string content, DateTime cacheTime)> pages;
        private readonly PageContentGetter actualGetter;


        public PageContentCachingProxy()
        {
            actualGetter = new PageContentGetter();
            pages = new Dictionary<string, (string content, DateTime cacheTime)>();
        }



        public string GetPage(string url)
        {
            string page = string.Empty;
            if (pages.ContainsKey(url))
            {

                Console.WriteLine("Getting page from Cache...");
                return pages[url].content ?? string.Empty;
            }

            page = string.Concat(actualGetter.GetPage(url).Take(300));
            pages[url] = (page, DateTime.Now);
            return page;
        }

    }














    #region cache with timeout : Not good locking, don't use in production

    //public class PageContentCachingProxyWithCacheTimeout : IPageContentGetter, IDisposable
    //{
    //    private Dictionary<string, (string content, DateTime cacheTime)> pages;
    //    private readonly PageContentGetter actualGetter;
    //    private System.Timers.Timer cleanUpTimer;

    //    // lock on pages dictionary
    //    private object removeOldCacheLock = new object();

    //    public PageContentCachingProxyWithCacheTimeout()
    //    {
    //        cleanUpTimer = new System.Timers.Timer();
    //        actualGetter = new PageContentGetter();
    //        pages = new Dictionary<string, (string content, DateTime cacheTime)>();
    //        RunCleanCacheEvery(TimeSpan.FromSeconds(2));
    //    }

    //    private void RunCleanCacheEvery(TimeSpan interval)
    //    {
    //        if (cleanUpTimer.Enabled)
    //            return;

    //        cleanUpTimer.Interval = interval.TotalMilliseconds;
    //        cleanUpTimer.Elapsed += Timer_Elapsed;
    //        cleanUpTimer.AutoReset = true;
    //        cleanUpTimer.Start();
    //    }


    //    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    //    {


    //        Console.WriteLine("start cleanning...");
    //        var limitTime = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(cleanUpTimer.Interval));
    //        var toremove = pages.Where(v => v.Value.cacheTime < limitTime)
    //            .ToList();
    //        toremove.ForEach(p =>
    //        {
    //            lock (removeOldCacheLock)
    //            {
    //                Console.WriteLine($"Clear URL form Cache: {p.Key} ");
    //                pages.Remove(p.Key);
    //            }

    //            Console.WriteLine($"Clear URL form Cache: {p.Key} ");
    //            pages.Remove(p.Key);

    //        });
    //        Console.WriteLine("end cleanning...");

    //    }

    //    public string GetPage(string url)
    //    {
    //        string page = string.Empty;

    //        lock (removeOldCacheLock)
    //        {
    //            if (pages.ContainsKey(url))
    //            {

    //                Console.WriteLine("Getting page from Cache...");
    //                return pages[url].content ?? string.Empty;
    //            }

    //            page = string.Concat(actualGetter.GetPage(url).Take(300));
    //            pages[url] = (page, DateTime.Now);
    //        }
    //        return page;
    //    }

    //    #region dispose pattern in c# not related to caching proxy pattern

    //    private bool disposedValue;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: dispose managed state (managed objects)
    //            }

    //            cleanUpTimer.Elapsed -= Timer_Elapsed;
    //            cleanUpTimer.Stop();

    //            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
    //            // TODO: set large fields to null
    //            disposedValue = true;
    //        }
    //    }

    //    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    //    // ~PageContentCachingProxy()
    //    // {
    //    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //    //     Dispose(disposing: false);
    //    // }

    //    public void Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //        Dispose(disposing: true);
    //        GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}

    #endregion

}
