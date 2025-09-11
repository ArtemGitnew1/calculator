using System;
class Calculator
{
    static double memory = 0;
    static double lastResult = 0;
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nКалькулятор");
            Console.WriteLine("1: +    2: -    3: *    4: /");
            Console.WriteLine("5: %    6: 1/x  7: x²   8: √x");
            Console.WriteLine("9: M+  10: M-  11: MR   0: Выход");
            Console.Write("Выберите: ");
            string choice = Console.ReadLine();
            if (choice == "0") break;
            switch (choice)
            {
                case "1": Calculate("+"); break;
                case "2": Calculate("-"); break;
                case "3": Calculate("*"); break;
                case "4": Calculate("/"); break;
                case "5": Calculate("%"); break;
                case "6": OneDelitNaX(); break;
                case "7": Kvadrat(); break;
                case "8": Koren(); break;
                case "9": 
                    // Возможная ошибка 1: Использование результата до вычисления - если вызвать M+ до любой операции
                    // lastResult будет равен 0 (значение по умолчанию), а не последнему результату
                    memory += lastResult; 
                    Console.WriteLine("Добавлено в память"); 
                    break;
                case "10": 
                    memory -= lastResult; 
                    Console.WriteLine("Вычтено из памяти"); 
                    break;
                case "11": Console.WriteLine("Память: " + memory); break;
                default: Console.WriteLine("Неверный выбор"); break;
            }
        }
        
        // Возможная ошибка 2: Возможна утечка ресурсов, так как консоль не закрывается явно
    }
    static void Calculate(string operation)
    {
        double a = GetNumber("Первое число: ");
        double b = GetNumber("Второе число: ");
        double result = 0;
        switch (operation)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/": 
                if (b == 0) { Console.WriteLine("Деление на 0!"); return; }
                result = a / b; 
                break;
            case "%": 
                if (b == 0) { Console.WriteLine("Деление на 0!"); return; }
                result = a % b; 
                break;
        }
        lastResult = result;
        Console.WriteLine("Ответ: " + result);
    }
    static void OneDelitNaX()
    {
        double x = GetNumber("Число: ");
        if (x == 0) { Console.WriteLine("Деление на 0!"); return; }
        lastResult = 1 / x;
        Console.WriteLine("Ответ: " + lastResult);
    }
    static void Kvadrat()
    {
        double x = GetNumber("Число: ");
        lastResult = x * x;
        Console.WriteLine("Ответ: " + lastResult);
    }
    static void Koren()
    {
        double x = GetNumber("Число: ");
        if (x < 0) { Console.WriteLine("Корень из отрицательного!"); return; }
        lastResult = Math.Sqrt(x);
        Console.WriteLine("Ответ: " + lastResult);
    }
    static double GetNumber(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        
        if (input.Length > 20)
        {
            Console.WriteLine("Слишком большое число!");
            Environment.Exit(0);
        }
        // Возможная ошибка 3: Игнорирование культурных настроек
        // double.Parse(input) может не работать с запятой как разделителем
        // Нужно использовать double.Parse(input, CultureInfo.InvariantCulture)
        return double.Parse(input);
    }
}