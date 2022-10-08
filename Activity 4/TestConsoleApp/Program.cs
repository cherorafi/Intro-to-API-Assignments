class Book<T> : Iintroduce
{
  private string name = ""; // field
    public string Name   // property
  {
    get { return name; }
    set { name = value; }
  }

  private T[] lines = new T[500];
  public T this[int x]{
    get {return lines[x];}
    set {lines[x] = value;}
  }


  public void sayName(){
    Console.WriteLine("The book is called", name);
  }
}

interface Iintroduce
{
    void sayName();
}



class Program
{
  static void Main(string[] args)
  {
    var aBook = new Book<string>();
    aBook.Name = "Curious George";
    aBook[0] = "George is a monkey";
    aBook.sayName();
  }
}