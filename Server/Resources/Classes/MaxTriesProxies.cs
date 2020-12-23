class Proxies
{

    public string Proxy { get; set; }
    public int CurrentTries { get; set; }
    public int MaxTries { get; set; }
    public bool ProxyBanned { get; set; }
    public bool InUse { get; set; }

    public Proxies(string Proxy)
    {
        this.Proxy = Proxy;
        this.ProxyBanned = false;
        this.InUse = false;

        this.CurrentTries = CurrentTries;
        this.MaxTries = MaxTries;

    }

    public void SetDefaults()
    {
        this.CurrentTries = 0;
        this.MaxTries = 
        this.ProxyBanned = false;
        this.InUse = false;
    }

    public string NewProxy()
    {
        return this.Proxy;
    }

    public void IncreaseTries()
    {
        CurrentTries++;
    }

    public void FinishedUsingProxy()
    {
        this.InUse = false;
    }

    public void UsingProxy()
    {
        this.InUse = true;
    }

    public void BanProxyUsage()
    {
        this.ProxyBanned = true;
    }

    public void UnbanProxy()
    {
        this.ProxyBanned = false;
    }

}

class ProxyHandler
{
    private List<Proxies> ProxyList { get; set; }
    private object locker;

    public int Timeout { get; set; }

    public Proxies NewProxy()
    {
        lock (ProxyList)
        {
            while (true)
            {
                foreach (Proxies proxy in ProxyList)
                {
                    if (proxy.ProxyBanned != true && proxy.InUse != true)
                    {
                        if (proxy.CurrentTries < proxy.MaxTries)
                        {
                            proxy.IncreaseTries();
                            proxy.UsingProxy();
                            return proxy;
                        }
                        else
                        {
                            proxy.BanProxyUsage();
                        }
                    }
                }
                TimeoutAllProxies();
                UnbanAllProxies();
            }

        }
    }

    public ProxyHandler(List<Proxies> ProxyList)
    {
        this.ProxyList = ProxyList;
        this.locker = new object();
    }

	public void SetTimeout()
	{
		this.Timeout = 
	}
    public void UnbanAllProxies()
    {
        foreach (Proxies proxy in ProxyList)
        {
            proxy.CurrentTries = 0;
            proxy.UnbanProxy();
        }
    }

    public void TimeoutAllProxies()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        while (true)
        {
            if (sw.ElapsedMilliseconds > 900000)
            {
                break;
            }
        }
    }

