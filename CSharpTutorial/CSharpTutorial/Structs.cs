using System;

namespace CSharpTutorial
{
	internal class Structs
	{
		// Yapılar C# dilinde değer tipi olan verilerdir.
		// Az sayıda eleman içerecek ve sadece bir veri tipi olabilecek değişkenleri yapı olarak tanımlamak hız ve verimlilik açısından daha faydalıdır.
		// Yapılar genellikle birbirleriyle ilişkili değişkenleri bir yapıda toplamak için kullanılır.
		// Yapılar kalıtımı desteklemez. Yani yapıları türetemeyiz.
		// Yapılar değer tipi oldukları için yapı türünden nesneler stack bellek bölgesinde saklanır.
		// Yapı nesneleri, faaliyet alanları bittiğinde otomatik olarak stack bölgesinden silinirler.
		// NOT: Değer tipindeki veri türleri aslında birer yapıdır. int veri türü aslında System.Int32 yapısını temsil eder.
		//      Değer tipi veri türleri ilk değer ataması yapılmadan kullanılamaz.
		// -Yapılarda yıkıcı metot bildirimi yapılamaz.
		// Avantajları: (Neden kullanmalıyız?)
		//  1.Stack bellek bölgesinde bir değişken için alan ayırmak aynı işi heap bölgesinde yapmaktan daha hızlıdır.
		//  2.Sınıf nesneleri Garbage Collection mekanizması ile heap alanından silinmektedir. Bu silme işleminin ne zaman olacağı kesin olarak belli değildir.
		//   Yani bir nesnenin faaliyet alanı bittiği anda yıkıcı metotlar çağrılmayabilir.
		//   Yapılarda yıkıcı metotlar olmamasına rağmen yapı nesnesinin faaliyet alanı dışına çıkıldığında nesne bellekten otomatik olarak silinir.
		//  3.Stack bölgesinde bulunan değişkenlerin kopyalanması daha hızlıdır.
		public struct Student
		{
			public string Name;
			public string Surname;
			public int Number;

			// Yapıların da sınıflar gibi birden fazla yapıcı metotları olabilir. Ancak varsayılan yapıcıyı kendimiz bildiremeyiz.
			// Yapılarda bildirilen bütün yapıcıların parametre alma zorunluluğu vardır.
			// Yapıcı metot bildirildiği zaman yapının bütün elemanlarına ilk değer verme zorunluluğu vardır.
			//  -Buradan yapıcı metotların, yapıda bulunan değişken sayısı kadar parametresinin olması gerektiği düşünülmemelidir.
			//  -Metot içerisinde; metoda parametre olarak gelmeyen elemana değer ataması yapılabilir. Örneğin; Number = 1;
			public Student(string name, string surname, int number)
			{
				Name = name;
				Surname = surname;
				Number = number;
			}
		}

		public static void ChangeStudentNumber(Student student)
		{
			student.Number = 321;
		}

		private static void Main()
		{
			// Bir yapı (struct) nesnesi tanımlamak için new anahtar sözcüğü kullanılabilir.
			// new anahtar sözcüğü kullanılınca yapının varsayılan yapıcı metodu ya da bizim tanımladığımız diğer yapıcı metotları çağırılır.
			// Yapılar parametresiz yapıcı metot içeremez.
			var john = new Student();
			Console.WriteLine(john.Number);

			// new anahtar sözcüğü kullanmadan da sınıflardan farklı olarak yapı nesnesi tanımlayabiliriz.
			// Bu şekilde tanımlanan yapı nesnelerine ilk değer atanmayacağı için her bir üye elemanına tek tek değer atanmalıdır.
			Student bill;
			bill.Number = 123;
			Console.WriteLine(bill.Number);

			// Değer tiplerinde birbirine atanan nesnelerde bitsel bir kopyalama işlemi olmaktadır. 
			// Bu yüzden aşağıdaki melinda nesnesi ile jennifer nesnesi atama operatörü ile birbirine atanmasına rağmen her iki nesne de stack bölgesinde farklı alanlarda tutulurlar.
			// Yani bu iki nesne birbirinden tamamen bağımsızdır. Biribi değiştirmek diğerini değiştirmeyecektir.
			var melinda = new Student { Number = 1212 };
			Student jennifer = melinda;
			melinda.Number = 999;
			Console.WriteLine(jennifer.Number); // Ekrana 1212 yazdığını görürsünüz. 

			// Yapılar metotlara parametre olarak aktarılırken de parametre değişkenleri bitsel kopyalamaya tabi tutulur.
			// Örneğin aşağıdaki kodda ChangeStudentNumber metodunu çağırıyoruz. Metoda parametre olarak gelen yapı değişkenini değiştirmemize rağmen orjinal değişkenin değeri değişmemiştir.
			var steve = new Student { Number = 111 };
			Console.WriteLine(steve.Number);
			ChangeStudentNumber(steve);
			Console.WriteLine(steve.Number);
		}
	}
}