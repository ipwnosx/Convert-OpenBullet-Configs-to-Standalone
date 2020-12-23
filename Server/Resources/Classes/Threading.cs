    class Threading
    {

        public static string[] Combo;

        private static List<Task> Tasks;

        static Threading()
        {
            Threading.Tasks = new List<Task>();
        }

        public Threading()
        {
        }

        public static void Initialize(int WorkersCount, Action<string> Target)
        {
            int length = (int)Threading.Combo.Length / WorkersCount;
            int num = 0;
            int num1 = 0;
            while (num1 <= WorkersCount)
            {
                int num2 = (num != 0 ? num + 1 : 0);
                int length1 = num2 + length;
                if (length1 < (int)Threading.Combo.Length - 2)
                {
                    if (num1 != WorkersCount)
                    {
                        Task task = new Task(() => Threading.Process(num2, length1, Threading.Combo, Target), TaskCreationOptions.LongRunning);
                        Threading.Tasks.Add(task);
                    }
                    else
                    {
                        length1 = (int)Threading.Combo.Length - 2;
                        Task task1 = new Task(() => Threading.Process(num2, length1, Threading.Combo, Target), TaskCreationOptions.LongRunning);
                        Threading.Tasks.Add(task1);
                    }
                    num = length1;
                    num1++;
                }
                else
                {
                    length1 = (int)Threading.Combo.Length - 2;
                    Task task2 = new Task(() => Threading.Process(num2, length1, Threading.Combo, Target), TaskCreationOptions.LongRunning);
                    Threading.Tasks.Add(task2);
                    break;
                }
            }
            Threading.Start();
        }

        public static void Process(int start, int end, string[] Combo, Action<string> doMethod)
        {
            for (int i = start; i <= end; i++)
            {
                doMethod(Combo[i]);
            }
        }

        private static void Start()
        {
            foreach (Task task in Threading.Tasks)
            {
                task.Start();
            }
        }

    