 var x = new
 {
    Items = new List<int> { 1, 2, 3 }.GetEnumerator()
 };
//while (x.Items.MoveNext()) // как было
//   Console.WriteLine(x.Items.Current);
var x_iterator = x.Items; // исправленный вариант - все время используем один и тот же enumerator
while (x_iterator.MoveNext())
    Console.WriteLine(x_iterator.Current);
// изначальный код не работает, т.к., обращаясь к методу Items, мы каждый раз заново вызываем GetEnumerator(), а он, в свою очередь, возвращает каждый раз новый enumerator, 
// который каждый раз заново ставится на место перед первым элементом коллекции (согласно документации на https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable.getenumerator?view=net-8.0)
// В случае, когда мы еще не вызвали MoveNext(), значение Current не определено, и поэтому оно возвращает значение типа int по умолчанию, т.е. 0.
// именно такой случай мы и видим в строке Console.WriteLine(x.Items.Current); т.к. вызываем в этой строчке заново GetEnumerator().
// ну и наконец, x.Items.MoveNext() всегда возвращает True, ведь мы каждый раз заново вызываем GetEnumerator(), поэтому MoveNext() каждый раз перемещает enumerator с места перед списком на первый элемент списка (т.е. следующий элемент всегда есть, это число 1, поэтому MoveNext() возвращает каждый раз True) получается условие while всегда выполнено, отсюда бесконечный цикл.
// именно поэтому код бесконечно пишет 0 в консоль.