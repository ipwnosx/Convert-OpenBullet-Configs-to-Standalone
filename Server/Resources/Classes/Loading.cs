class Load
	{

		public static List<string> combosList = new List<string>();
		public static List<string> proxyList = new List<string>();

		public static List<Proxies> proxyHandlerList = new List<Proxies>();
		
		public static bool LoadFiles()
		{
			string[] combo = File.ReadAllLines("Assets\\ComboList.txt");
			string[] proxy = File.ReadAllLines("Assets\\ProxyList.txt");

			foreach (string line in combo)
			{
				combosList.Add(line);
			}	

			Threading.Combo = combosList.ToArray();

			foreach (string line2 in proxy)
			{
				proxyList.Add(line2);
			}

			foreach (string line3 in proxyList)
			{
				proxyHandlerList.Add(new Proxies(line3));
			}


			if (combosList.Count() > 0)
			{


				return true;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Either your proxy or Combo lists are empty.");
				Console.ResetColor();
				Console.ReadKey();
				Environment.Exit(0);
				return false;
			}


		}
	
	