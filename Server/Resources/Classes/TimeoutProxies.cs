class Proxies
    {

        public string Proxy { get; set; }
        public bool ProxyBanned { get; set; }
        public bool InUse { get; set; }

        public Proxies(string Proxy)
        {
            this.Proxy = Proxy;
            this.ProxyBanned = false;
            this.InUse = false;
        }

        public void SetDefaults()
         {
        this.ProxyBanned = false;
        this.InUse = false;
         }
        public string NewProxy()
        {
            return this.Proxy;
        }

        public void UsingProxy()
        {
            this.InUse = true;
        }

        public void FinishedUsingProxy()
        {
            this.InUse = false;
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
                                proxy.UsingProxy();
                                return proxy;

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

        public void UnbanAllProxies()
        {
            foreach (Proxies proxy in ProxyList)
            {

                proxy.UnbanProxy();
            }
        }

         public void SetTimeout()
         {
              this.Timeout = 
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
    