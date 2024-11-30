namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToDirectory = "C:\\Users\\Feona\\Test — копия";
            long catalogSize = 0;
            int countDelete = 0;
            catalogSize = sizeOfFolder(pathToDirectory, ref catalogSize, ref countDelete); 
            if (catalogSize != 0)
            {
                Console.WriteLine("Размер папки {0} составляет: {1} Байт\nФайлов удалено {2}", pathToDirectory, catalogSize, countDelete);
            }
            else
            {
                Console.WriteLine("Каталог {0} пуст.", pathToDirectory);
            }
            Console.WriteLine($"\nИсходный размер папки: {catalogSize} байт");
            Console.WriteLine($"Освобождено: {catalogSize} байт");
            catalogSize = 0;
            catalogSize = sizeOfFolder(pathToDirectory, ref catalogSize, ref countDelete); 
            Console.WriteLine($"Текущий размер папки: {catalogSize} байт");
        }
        static long sizeOfFolder(string folder, ref long catalogSize, ref int countDelete)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                
                foreach (FileInfo f in fi)
                {
                    //Console.WriteLine("\nИмя файла: " + f.Name);
                    catalogSize = catalogSize + f.Length;
                    //Console.WriteLine($"Размер файла: {catalogSize}");
                    f.Delete();
                    countDelete++;
                    //Console.WriteLine("Файл удален: " + f + "\n");
                }

                foreach (DirectoryInfo df in diA)
                {
                    
                    //Console.WriteLine("\nИмя папки: " + df.Name);
                    sizeOfFolder(df.FullName, ref catalogSize, ref countDelete);
                    //Console.WriteLine($"Размер папки: {sizeOfFolder}");
                    df.Delete(true);
                    //Console.WriteLine("Папка удалена: " + df + "\n");
                    //Console.WriteLine("Освобождено:" + sizeOfFolder);
                }
                return catalogSize;
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                return 0;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка. Обратитесь к администратору. Ошибка: " + ex.Message);
                return 0;
            }
        }

    }
}