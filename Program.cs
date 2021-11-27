Person sam = new("Sam", 25); 
sam.Print();          // Имя: Sam  Возраст: 25

Person Maxim = new(name: "Maxim", age: 28); 
Maxim.Print();          // Имя: Sam  Возраст: 25
class Person   
{
    public string name;
    public int age;
    
    public Person(string name, int age) 
    { 
        this.name = name; 
        this.age = age; 
    }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");


}

//* Maxim.Print(); 
//! получить доступ к классу
